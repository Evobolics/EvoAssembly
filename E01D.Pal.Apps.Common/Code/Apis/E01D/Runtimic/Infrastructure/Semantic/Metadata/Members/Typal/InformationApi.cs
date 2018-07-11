using System;
using System.Runtime.CompilerServices;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public class InformationApi<TContainer> : SemanticApiNode<TContainer>, InformationApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        /// <summary>
        /// Creates a SemanticTypeInformation instance from a System.Type.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="inputType"></param>
        /// <returns></returns>
        public SemanticTypeInformation CreateTypeInformation(InfrastructureModelMask_I model, System.Type inputType)
        {


            if (inputType?.FullName == null) return null;

           

            var typeInformation = new SemanticTypeInformation
            {
                Name = inputType.Name,
                FullName = inputType.FullName,
                IsDelegate = inputType.BaseType?.FullName == "System.Delegate" || inputType.BaseType?.FullName == "System.MulticastDelegate",
                IsArray = inputType.IsArray,
                IsClass = inputType.IsClass,
                IsInterface = inputType.IsInterface,
                IsEnum = inputType.IsEnum,
                IsOpenGeneric = inputType.ContainsGenericParameters,
                IsClosedGeneric = inputType.GenericTypeArguments.Length > 0 && !inputType.ContainsGenericParameters,
                IsGlobal = inputType.MetadataToken == 1,
                IsNested = inputType.IsNested,
                IsValueType = inputType.IsValueType,
                
            };

            typeInformation.IsGeneric = typeInformation.IsOpenGeneric || typeInformation.IsClosedGeneric;

            typeInformation.IsAnonymousType = IsAnonymousType(inputType);

            if (typeInformation.IsOpenGeneric)
            {
                typeInformation.GenericKind |= GenericTypeKind.Open;
            }

            if (typeInformation.IsClosedGeneric)
            {
                typeInformation.GenericKind |= GenericTypeKind.Closed;
            }

            if (inputType.GenericTypeArguments.Length > 0)
            {
                typeInformation.GenericKind |= GenericTypeKind.HasTypeArguments;
            }

            if (inputType.ContainsGenericParameters)
            {
                typeInformation.GenericKind |= GenericTypeKind.HasTypeParameters;
            }


            // Add the type information before any 
            //model.Types.TypeInformations.Add(inputType.FullName, typeInformation);
            if (inputType.GenericTypeArguments.Length > 0)
            {
                var blueprint = inputType.GetGenericTypeDefinition();

                typeInformation.GenericTypeDefinition = Infrastructure.Models.Structural.Types.Collection.GetStoredTypeReference(model, blueprint);
            }
            else
            {
                typeInformation.TypeReference = Infrastructure.Models.Structural.Types.Collection.GetStoredTypeReference(model, inputType);
            }
            
            //// The issue is that type arguments can be generics themselves.  
            //// The issue also is that arguments could have already been created.
            //typeInformation.TypeArguments = GetTypeParameters(model, inputType);
            //typeInformation.Interfaces = GetInterfaces(model, inputType);

            return typeInformation;
        }


        public SemanticTypeInformation CreateTypeInformation(InfrastructureModelMask_I model, TypeReference typeReference)
        {
            //if (typeReference.FullName ==
            //    "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.GenericClassWithMethods`1"
            //)
            //{

            //}

            var typeInformation = new SemanticTypeInformation
            {
                Name = typeReference.Name,
                FullName = typeReference.FullName,
                TypeReference = typeReference
            };

            if (typeReference.IsDefinition)
            {
                var typeDefinition = (TypeDefinition)typeReference;
                typeInformation.IsDelegate = typeDefinition.BaseType?.FullName == "System.Delegate" || typeDefinition.BaseType?.FullName == "System.MulticastDelegate";
                typeInformation.IsArray = typeDefinition.IsArray;
                typeInformation.IsClass = typeDefinition.IsClass;
                typeInformation.IsInterface = typeDefinition.IsInterface;
                typeInformation.IsEnum = typeDefinition.IsEnum;
                typeInformation.IsGlobal = typeDefinition.MetadataToken.RID == 1;
                typeInformation.IsNested = typeDefinition.IsNested;
                typeInformation.IsValueType = typeDefinition.IsValueType;
                
                typeInformation.IsOpenGeneric = typeDefinition.GenericParameters.Count > 0;

                if (typeInformation.IsOpenGeneric)
                {
                    typeInformation.GenericKind |= GenericTypeKind.Open;
                }

                if (typeDefinition.GenericParameters.Count > 0)
                {
                    typeInformation.GenericKind |= GenericTypeKind.HasTypeParameters;
                }

                typeInformation.IsGeneric = typeInformation.IsOpenGeneric || typeInformation.IsClosedGeneric;

                typeInformation.IsAnonymousType = IsAnonymousType(typeInformation.IsGeneric, typeDefinition.Name, typeDefinition.Attributes);


            }
	        else if (typeReference.IsPointer)
	        {
		        var pointerDefinition = (PointerType)typeReference;
		        typeInformation.IsPointer = true;
		        typeInformation.IsDelegate = false;
		        typeInformation.IsArray = pointerDefinition.IsArray;
		        typeInformation.IsClass = false;
		        typeInformation.IsInterface = false;
		        typeInformation.IsEnum = false;
		        typeInformation.IsGlobal = pointerDefinition.MetadataToken.RID == 1;
		        typeInformation.IsNested = pointerDefinition.IsNested;
		        typeInformation.IsValueType = pointerDefinition.IsValueType;

		        typeInformation.IsOpenGeneric = pointerDefinition.GenericParameters.Count > 0;

		        if (typeInformation.IsOpenGeneric)
		        {
			        typeInformation.GenericKind |= GenericTypeKind.Open;
		        }

		        if (pointerDefinition.GenericParameters.Count > 0)
		        {
			        typeInformation.GenericKind |= GenericTypeKind.HasTypeParameters;
		        }

		        typeInformation.IsGeneric = typeInformation.IsOpenGeneric || typeInformation.IsClosedGeneric;

		        typeInformation.IsAnonymousType = false;


	        }
            else if (typeReference.IsRequiredModifier)
            {
	            var requiredModifierDefinition = (RequiredModifierType)typeReference;
	            typeInformation.IsRequiredModifier = true;
	            typeInformation.IsDelegate = false;
	            typeInformation.IsArray = requiredModifierDefinition.IsArray;
	            typeInformation.IsClass = false;
	            typeInformation.IsInterface = false;
	            typeInformation.IsEnum = false;
	            typeInformation.IsGlobal = requiredModifierDefinition.MetadataToken.RID == 1;
	            typeInformation.IsNested = requiredModifierDefinition.IsNested;
	            typeInformation.IsValueType = requiredModifierDefinition.IsValueType;

	            typeInformation.IsOpenGeneric = requiredModifierDefinition.GenericParameters.Count > 0;

	            if (typeInformation.IsOpenGeneric)
	            {
		            typeInformation.GenericKind |= GenericTypeKind.Open;
	            }

	            if (requiredModifierDefinition.GenericParameters.Count > 0)
	            {
		            typeInformation.GenericKind |= GenericTypeKind.HasTypeParameters;
	            }

	            typeInformation.IsGeneric = typeInformation.IsOpenGeneric || typeInformation.IsClosedGeneric;

	            typeInformation.IsAnonymousType = false;


            }
			else if (typeReference.IsArray)
            {
                typeInformation.IsDelegate = false;
                typeInformation.IsArray = true;
                typeInformation.IsClass = false;
                typeInformation.IsInterface = false;
                typeInformation.IsEnum = false;
                typeInformation.IsGlobal = false;
                typeInformation.IsNested = false;
                typeInformation.IsValueType = false;
                typeInformation.IsOpenGeneric = false;
                typeInformation.IsAnonymousType = false;
            }
            else if (typeReference.IsGenericInstance)
            {
                var genericInstanceType = (GenericInstanceType)typeReference;
                typeInformation.IsArray = genericInstanceType.IsArray;


                typeInformation.IsGlobal = genericInstanceType.MetadataToken.RID == 1;
                typeInformation.IsNested = genericInstanceType.IsNested;
                typeInformation.IsValueType = genericInstanceType.IsValueType;
                typeInformation.IsOpenGeneric = genericInstanceType.GenericParameters.Count > 0;
                typeInformation.IsClosedGeneric = genericInstanceType.GenericArguments.Count > 0 &&!(genericInstanceType.GenericParameters.Count > 0);

                TypeDefinition elementTypeReference = Types.GenericInstances.GetElementType(model, genericInstanceType);
                typeInformation.IsDelegate = elementTypeReference.BaseType?.FullName == "System.Delegate" || elementTypeReference.BaseType?.FullName == "System.MulticastDelegate";
                typeInformation.IsArray = genericInstanceType.IsArray;
                typeInformation.IsClass = elementTypeReference.IsClass;
                typeInformation.IsInterface = elementTypeReference.IsInterface;
                typeInformation.IsEnum = elementTypeReference.IsEnum;

                if (typeInformation.IsOpenGeneric)
                {
                    typeInformation.GenericKind |= GenericTypeKind.Open;
                }

                if (typeInformation.IsClosedGeneric)
                {
                    typeInformation.GenericKind |= GenericTypeKind.Closed;
                }

                if (genericInstanceType.GenericArguments.Count > 0)
                {
                    typeInformation.GenericKind |= GenericTypeKind.HasTypeArguments;
                }

                if (genericInstanceType.GenericParameters.Count > 0)
                {
                    typeInformation.GenericKind |= GenericTypeKind.HasTypeParameters;
                }

                typeInformation.IsGeneric = typeInformation.IsOpenGeneric || typeInformation.IsClosedGeneric;

                typeInformation.IsAnonymousType = IsAnonymousType(typeInformation.IsGeneric, genericInstanceType.Name, elementTypeReference.Attributes);

                // Add the type information before any 
                //model.Types.TypeInformations.Add(inputType.FullName, typeInformation);
                if (genericInstanceType.GenericArguments.Count > 0)
                {
                    var blueprint = genericInstanceType.ElementType;

                    typeInformation.GenericTypeDefinition =  blueprint;
                }
                else
                {
                    throw new System.Exception("Not expected");
                }
            }
            else
            {
                throw new System.Exception("Not expected");
            }

            return typeInformation;
        }

        private bool IsAnonymousType(System.Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            // HACK
            return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
                   && type.IsGenericType && type.Name.Contains("AnonymousType")
                   && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
                   && (type.Attributes & System.Reflection.TypeAttributes.NotPublic) == System.Reflection.TypeAttributes.NotPublic;
        }

        private bool IsAnonymousType(bool isGeneric, string name, TypeAttributes typeAttributes)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            // HACK
            return isGeneric && name.Contains("AnonymousType")
                   && (name.StartsWith("<>") || name.StartsWith("VB$"))
                   && (typeAttributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic;
        }

        
    }
}
