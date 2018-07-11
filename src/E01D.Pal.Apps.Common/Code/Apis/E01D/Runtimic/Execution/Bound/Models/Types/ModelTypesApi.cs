using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Domains.E01D;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
    public class ModelTypesApi<TContainer> : BindingApiNode<TContainer>, ModelTypesApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public CollectionApi_I<TContainer> Collection { get; set; }

		public ExternalApi_I<TContainer> External { get; set; }

	    CollectionApiMask_I ModelTypesApiMask_I.Collection => Collection;

		ExternalApiMask_I ModelTypesApiMask_I.External => External;

		

        

        

        

        

        public System.Type GetObjectType(InfrastructureModel_I model)
        {
            return GetBoundUnderlyingTypeOrThrow(model, typeof(Object).AssemblyQualifiedName);
        }

        public System.Type GetValueType(InfrastructureModel_I model)
        {
            return GetBoundUnderlyingTypeOrThrow(model, typeof(ValueType).AssemblyQualifiedName);
        }

        public System.Type GetEnumType(InfrastructureModel_I model)
        {
            return GetBoundUnderlyingTypeOrThrow(model, typeof(Enum).AssemblyQualifiedName);
        }



	    public System.Type GetUnderlyingType(InfrastructureModelMask_I model, TypeReference typeReference)
	    {
		    if (typeReference.IsGenericParameter)
		    {
			    var bound = ResolveToBound_GenericParameter(model, (GenericParameter) typeReference);

			    return bound.UnderlyingType;
		    }

		    if (typeReference.IsGenericInstance)
		    {
			    var genericInstance = (GenericInstanceType)typeReference;

			    var genericTypeDefinitionType = GetUnderlyingType(model, genericInstance.ElementType);

			    System.Type[] genericArguments = new System.Type[genericInstance.GenericArguments.Count];

			    for (int i = 0; i < genericInstance.GenericArguments.Count; i++)
			    {
				    genericArguments[i] = GetUnderlyingType(model, genericInstance.GenericArguments[i]);

			    }

			    return XCommonAppPal.Api.Runtimic.Execution.Metadata.Assemblies.MakeGenericType(genericTypeDefinitionType, genericArguments);
		    }

		    return Cecil.GetUnderlyingType(typeReference);

		}

        

        public System.Type GetBoundUnderlyingTypeOrThrow(InfrastructureModelMask_I model, string resolutionName)
        {
            var semanticType = Collection.GetOrThrow(model, resolutionName);

            return GetBoundUnderlyingTypeOrThrow(semanticType);
        }

        public System.Type GetBoundUnderlyingTypeOrThrow(SemanticTypeMask_I semanticType)
        {
            var boundType = GetBoundTypeOrThrow(semanticType, false);

            if (boundType.UnderlyingType == null)
            {
                throw new System.Exception("Expected the underlying type to be filled in with a instance of a runtime type.");
            }

            return boundType.UnderlyingType;
        }

        public BoundTypeDefinitionMask_I GetBoundTypeOrThrow(SemanticTypeMask_I semanticType, bool allowNulls)
        {
            if (semanticType == null)
            {
                if (allowNulls) return null;

                throw new System.Exception("The semantic type is null.");
            }


            if (!semanticType.IsBound())
            {
                throw new System.Exception("Expected any type in the conversion graph to be at least a bound type.");
            }

            return (BoundTypeDefinitionMask_I)semanticType;
        }

        public TypeReference GetTypeReference(InfrastructureModelMask_I model, Type input)
        {
            return Infrastructure.Models.Semantic.Types.GetTypeReference(model, input);
        }

	    public TypeReference GetTypeReference(InfrastructureModelMask_I model, Type input, out SemanticTypeDefinitionMask_I possibleSemanticType)
	    {
		    return Infrastructure.Models.Semantic.Types.GetTypeReference(model, input, out possibleSemanticType);
	    }

		public TypeDefinition Resolve(InfrastructureModel_I model, Type genericTypeDefinitionType)
        {
            return (TypeDefinition)Infrastructure.Models.Structural.Types.Collection.GetStoredTypeReference(model, genericTypeDefinitionType);
        }

	    public System.Type ResolveToType(InfrastructureModelMask_I model, TypeReference typeReference, System.Type underlyingType, out BoundTypeDefinitionMask_I boundType)
	    {
		    boundType = ResolveToBound(model, typeReference, underlyingType);

		    return underlyingType;
	    }

		public System.Type ResolveToType(InfrastructureModelMask_I model, TypeReference typeReference, out BoundTypeDefinitionMask_I boundType)
	    {
		    boundType = ResolveToBound(model, typeReference);

		    return ResolveToType(model, boundType);
	    }

		public Type ResolveToType(InfrastructureModelMask_I model, TypeReference typeReference)
		{
			var semanticType = Types.Ensuring.Ensure(model, typeReference);

			if (semanticType is BoundTypeDefinitionMask_I bound)
			{
				if (bound.UnderlyingType != null)
				{
					return bound.UnderlyingType;
				}

				throw new Exception("Undelrying type is null");
			}

			throw new Exception("There was not a bound type mapped to the type reference.");
		}

        public System.Type ResolveToType(InfrastructureModelMask_I model, SemanticTypeDefinitionMask_I semanticType, out BoundTypeDefinitionMask_I resultingBound)
        {
            if (!semanticType.IsBound())
            {
                resultingBound = null;

                return Infrastructure.Models.Semantic.Types.ResolveToType(model, semanticType);
            }

            // Can only build and bake types that are definitions.  References cannot be turned into full types.
            if (!(semanticType is BoundTypeDefinitionMask_I bound))
            {
                throw new Exception("Can only resolve semantic types to System.Types that are bound definitions.");
            }

            resultingBound = bound;

            return ResolveToType(model, bound);
        }

        

        // TODO: Rename to GetRuntimeType
        public System.Type ResolveToType(InfrastructureModelMask_I model, BoundTypeDefinitionMask_I semanticType)
        {
            
            // TODO: 2) Building needs to be decoupled from baking, to allow for field types to be resolved without causing the baking to occur that can prevent other fields 
            //          from being added.

            var underlyingType = semanticType.UnderlyingType;

            if (underlyingType == null)
            {
                throw new System.Exception("Expected the underlying type to be filled in with a instance of a runtime type.");
            }

            return underlyingType;
            
        }


	    public BoundTypeDefinitionMask_I ResolveToBound(InfrastructureModelMask_I model, TypeReference typeReference)
	    {
		    return ResolveToBound(model, typeReference, null);
	    }


		public BoundTypeDefinitionMask_I ResolveToBound(InfrastructureModelMask_I model, TypeReference typeReference, Type underlyingType)
        {
            if (typeReference.IsGenericParameter)
            {
                GenericParameter parameter = (GenericParameter)typeReference;

                return ResolveToBound_GenericParameter(model, parameter);
            }

            SemanticTypeMask_I semanticMask = Types.Ensuring.Ensure(model, typeReference, underlyingType);

            if (!(semanticMask is BoundTypeDefinitionMask_I bound))
            {
                throw new Exception($"Expected the resolved semantic type of type '{semanticMask.GetType()}' to be a bound type definition.");
            }

            return bound;
        }

        /// <summary>
        /// Will resolve a type reference that is a generic parameter to a bound type.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="typeReference"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private BoundTypeDefinitionMask_I ResolveToBound_GenericParameter(InfrastructureModelMask_I model, GenericParameter parameter)
        {
            // At this point, we do not know if the parameter is belongs to a converted type or not.
            if (parameter.DeclaringType != null)
            {
                // This will determine if it needs to go the converted route or non-converted based upon the model types.
                var declaringType = Types.Ensuring.Ensure(model, parameter.DeclaringType);

                // Assumign that bound types also add their generic parameters to the collection, this will work.

                return TypeParameters.Resolve(model, declaringType, parameter);
            }
            else
            {
                if (!(parameter.DeclaringMethod is MethodDefinition methodDefinition))
                {
                    throw new Exception("Expected a method definition");
                }

                // This will determine if it needs to go the converted route or non-converted based upon the model types.
                var declaringType = Types.Ensuring.Ensure(model, methodDefinition.DeclaringType);

                return TypeParameters.Resolve(model, declaringType, methodDefinition, parameter);
            }
        }

		


	}
}
