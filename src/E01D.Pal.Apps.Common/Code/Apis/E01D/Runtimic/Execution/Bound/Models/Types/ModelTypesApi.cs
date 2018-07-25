using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Domains.E01D;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
    public class ModelTypesApi<TContainer> : BoundApiNode<TContainer>, ModelTypesApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public CollectionApi_I<TContainer> Collection { get; set; }

		public ExternalApi_I<TContainer> External { get; set; }

	    CollectionApiMask_I ModelTypesApiMask_I.Collection => Collection;

		ExternalApiMask_I ModelTypesApiMask_I.External => External;

		

        

        

        

        

        public System.Type GetObjectType(BoundRuntimicModelMask_I model)
        {
            return GetBoundUnderlyingTypeOrThrow(model, typeof(Object).AssemblyQualifiedName);
        }

        public System.Type GetValueType(BoundRuntimicModelMask_I model)
        {
            return GetBoundUnderlyingTypeOrThrow(model, typeof(ValueType).AssemblyQualifiedName);
        }

       


	    public System.Type GetUnderlyingType(BoundRuntimicModelMask_I model, TypeReference typeReference)
	    {
		    if (typeReference.IsGenericParameter)
		    {
			    var bound = ResolveToBound_GenericParameter(model, (GenericParameter) typeReference);

			    return bound.UnderlyingType;
		    }

		    if (typeReference.IsGenericInstance)
		    {
			    throw new Exception("Should never happen.");
			    //var genericInstance = (GenericInstanceType)typeReference;

			    //var genericTypeDefinitionType = GetUnderlyingType(model, genericInstance.ElementType);

			    //System.Type[] genericArguments = new System.Type[genericInstance.GenericArguments.Count];

			    //for (int i = 0; i < genericInstance.GenericArguments.Count; i++)
			    //{
				   // genericArguments[i] = GetUnderlyingType(model, genericInstance.GenericArguments[i]);

				   // if (genericArguments[i] == null)
				   // {
					  //  throw new Exception("The underlying type was null.");
				   // }

			    //}

			    //var result = XCommonAppPal.Api.Runtimic.Execution.Metadata.Assemblies.MakeGenericType(genericTypeDefinitionType, genericArguments);

			    //return result;
		    }

		    return Cecil.GetUnderlyingType(typeReference);

		}

        

        public System.Type GetBoundUnderlyingTypeOrThrow(BoundRuntimicModelMask_I model, string resolutionName)
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

        public TypeReference GetTypeReference(BoundRuntimicModelMask_I model, Type input)
        {
            return Infrastructure.Models.Semantic.Types.GetTypeReference(model, input);
        }

	    public TypeReference GetTypeReference(BoundRuntimicModelMask_I model, Type input, out SemanticTypeDefinitionMask_I possibleSemanticType)
	    {
		    return Infrastructure.Models.Semantic.Types.GetTypeReference(model, input, out possibleSemanticType);
	    }

		public TypeDefinition Resolve(BoundRuntimicModelMask_I model, Type genericTypeDefinitionType)
        {
            return (TypeDefinition)Cecil.Types.Getting.GetStoredTypeReference(model, genericTypeDefinitionType);
        }

	    

		public Type ResolveToType(BoundRuntimicModelMask_I model, TypeReference typeReference)
		{
			var semanticType = Execution.Types.Ensuring.Ensure(model, typeReference, null, null);

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

        

        

        


	    //public BoundTypeDefinitionMask_I ResolveToBound(BoundRuntimicModelMask_I model, TypeReference typeReference)
	    //{
		   // return ResolveToBound(model, typeReference, null);
	    //}


		//public BoundTypeDefinitionMask_I ResolveToBound(BoundRuntimicModelMask_I model, TypeReference typeReference, Type underlyingType)
  //      {
  //          if (typeReference.IsGenericParameter)
  //          {
  //              GenericParameter parameter = (GenericParameter)typeReference;

  //              return ResolveToBound_GenericParameter(model, parameter);
  //          }

  //          SemanticTypeMask_I semanticMask = Execution.Types.Ensuring.Ensure(model, typeReference, underlyingType, null);

  //          if (!(semanticMask is BoundTypeDefinitionMask_I bound))
  //          {
  //              throw new Exception($"Expected the resolved semantic type of type '{semanticMask.GetType()}' to be a bound type definition.");
  //          }

  //          return bound;
  //      }

        /// <summary>
        /// Will resolve a type reference that is a generic parameter to a bound type.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="typeReference"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private BoundTypeDefinitionMask_I ResolveToBound_GenericParameter(BoundRuntimicModelMask_I model, GenericParameter parameter)
        {
            // At this point, we do not know if the parameter is belongs to a converted type or not.
            if (parameter.DeclaringType != null)
            {
                // This will determine if it needs to go the converted route or non-converted based upon the model types.
                var declaringType = Execution.Types.Ensuring.Ensure(model, parameter.DeclaringType, null, null);

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
                var declaringType = Execution.Types.Ensuring.Ensure(model, methodDefinition.DeclaringType, null, null);

                return TypeParameters.Resolve(model, declaringType, methodDefinition, parameter);
            }
        }

		


	}
}
