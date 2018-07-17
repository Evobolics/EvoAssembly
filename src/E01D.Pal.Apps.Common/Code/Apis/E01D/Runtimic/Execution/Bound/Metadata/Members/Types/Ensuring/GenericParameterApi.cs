using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
    public class GenericParameterApi<TContainer> : BoundApiNode<TContainer>, GenericParameterApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I model, TypeReference typeReference)
        {
            if (!typeReference.IsGenericParameter)
            {
                throw new Exception("Should only be used to get a semantic type for a generic argument.");
            }

            GenericParameter parameter = (GenericParameter)typeReference;

            if (parameter.DeclaringType != null)
            {
                var declaringSemanticType = Execution.Types.Ensuring.Ensure(model, parameter.DeclaringType, null, null);

                if (!declaringSemanticType.IsGeneric())
                {
                    throw new Exception("Expected the resolved semantic type to be a generic type.");
                }

                SemanticGenericTypeDefinitionMask_I generic = (SemanticGenericTypeDefinitionMask_I)declaringSemanticType;

                if (!generic.TypeParameters.ByName.TryGetValue(typeReference.Name, out SemanticGenericParameterTypeDefinitionMask_I semanticTypeParameter))
                {
                    throw new Exception("Expected the generic type to have a type parameter named.");
                }

                if (!semanticTypeParameter.IsBound())
                {
                    throw new Exception("Expected the generic parameter type to be a bound type.");
                }

                return (BoundTypeDefinitionMask_I)semanticTypeParameter;
            }
            else
            {
                throw new Exception("Method generic parameters not supported yet.");
            }

        }
    }
}
