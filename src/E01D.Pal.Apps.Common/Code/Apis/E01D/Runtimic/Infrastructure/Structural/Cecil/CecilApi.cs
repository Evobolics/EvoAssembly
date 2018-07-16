using System;
using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil
{
    

    public class CecilApi<TContainer> : CecilApiNode<TContainer>, CecilApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

	    
		public MetadataApi_I<TContainer> Metadata { get; set; }

	    MetadataApiMask_I CecilApiMask_I.Metadata => Metadata;

	    

		

        public System.Type GetUnderlyingType(TypeReference input)
        {
	        if (input.IsGenericInstance)
	        {
		        var genericInstance = (GenericInstanceType)input;

		        var genericTypeDefinitionType = GetUnderlyingType(genericInstance.ElementType);

		        System.Type[] genericArguments = new System.Type[genericInstance.GenericArguments.Count];

		        for (int i = 0; i < genericInstance.GenericArguments.Count; i++)
		        {
			        genericArguments[i] = GetUnderlyingType(genericInstance.GenericArguments[i]);

		        }

		        return genericTypeDefinitionType.MakeGenericType(genericArguments);

	        }

	        var assemblyQualifiedName = Metadata.Members.Types.Naming.GetAssemblyQualifiedName(input);

			System.Type underlyingType = System.Type.GetType(assemblyQualifiedName, false);

            if (underlyingType == null)
            {
                var loadedAssembly = System.Reflection.Assembly.Load(Metadata.Assemblies.Naming.GetAssemblyName(input));

                underlyingType = this.Execution.Binding.Metadata.Assemblies.GetTypeFromAssembly(loadedAssembly, input.FullName);
            }

            // TODO: need to have an exclusion list.
            // Certain types like "<Module>" are not goign to return a type.
            if (underlyingType == null && (input is TypeDefinition typeDefinition && typeDefinition.MetadataToken.RID != 1)
                && input.FullName != "System.Runtime.Remoting.Proxies.__TransparentProxy")
            {
                throw new System.Exception("Could not create bound type.  Could not find underlying type to bind to bound type.");
            }

            return underlyingType;
        }

        

        public TypeReference GetBaseType(TypeReference typeReference)
        {
            if (typeReference.IsDefinition)
            {
                return ((TypeDefinition) typeReference).BaseType;
            }
            if (typeReference.IsGenericInstance)
            {
                var genericInstance = (GenericInstanceType) typeReference;

                // Step 1: get the element type
                var genericReference = genericInstance.ElementType;

                if (genericReference.IsDefinition)
                {
                    var genericDefinition = (TypeDefinition) genericReference;

                    var genericDefinitionBaseReference = genericDefinition.BaseType;

                    if (!genericDefinitionBaseReference.HasGenericParameters)
                    {
                        return genericDefinitionBaseReference;
                    }

                    throw new System.Exception("NOt implemented yet.");
                }
                else
                {
                    throw new System.Exception("NOt implemented yet.");
                }
            }
            else
            {
                throw new System.Exception("Type reference type not implemented yet.  This shoudl not happen.");
            }
        }

        public TypeReference ResolveForTypeScan(TypeReference genericArgumentSource, TypeReference returnTypeReference)
        {
            if (returnTypeReference.IsArray)
            {
                var arrayType = (ArrayType) returnTypeReference;

                return arrayType.ElementType;
            }

            if (returnTypeReference.IsGenericInstance)
            {
                var generic = (GenericInstanceType) returnTypeReference;

                // You can ignore the generic arguments.  They are resolved when the initial type is resolved.
                return generic.ElementType;
            }

            return returnTypeReference;
        }

        public TypeReference ResolveAnyTypeArguments(TypeReference genericArgumentSource, TypeReference returnTypeReference)
        {
            if (returnTypeReference.HasGenericParameters)
            {
                throw new Exception("Generic argument source not implemented yet.");
            }

            return returnTypeReference;
        }

        public TypeDefinition GetFundamentalTypeDefinition(TypeReference typeReference)
        {
            if (typeReference.IsDefinition)
            {
                return (TypeDefinition) typeReference;
            }
            else if (typeReference.IsGenericInstance)
            {
                var genericInstance = (GenericInstanceType)typeReference;

                return (TypeDefinition) genericInstance.ElementType;
            }

            throw new Exception("Not implemented");
        }

	    


	    public PackingSize GetPackingSize(TypeDefinition typeDefinition)
        {
            switch (typeDefinition.PackingSize)
            {
                case -1:
                    return PackingSize.Unspecified;
                case 0:
                    return PackingSize.Unspecified;
                case 1:
                    return PackingSize.Size1;
                case 2:
                    return PackingSize.Size2;
                case 4:
                    return PackingSize.Size4;
                case 8:
                    return PackingSize.Size8;
                case 16:
                    return PackingSize.Size16;
                case 32:
                    return PackingSize.Size32;
                case 64:
                    return PackingSize.Size64;
                case 128:
                    return PackingSize.Size128;
                default:
                {
                    throw new NotSupportedException($"Packing size {typeDefinition.PackingSize} is not supported.");
                }
            }


        }

        static MethodReference MakeGeneric(MethodReference method, TypeReference declaringType)
        {
            var reference = new MethodReference(method.Name, method.ReturnType);

            reference.HasThis = method.HasThis;
            reference.ExplicitThis = method.ExplicitThis;
            reference.CallingConvention = MethodCallingConvention.Generic;
	        foreach (var parameter in method.Parameters)
	        {
		        reference.Parameters.Add(new ParameterDefinition(parameter.ParameterType));
	        }

	        return reference;
        }
    }
}
