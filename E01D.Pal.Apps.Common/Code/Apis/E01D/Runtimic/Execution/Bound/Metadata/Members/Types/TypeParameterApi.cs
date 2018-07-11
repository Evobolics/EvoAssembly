using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
    public class TypeParameterApi<TContainer> : BindingApiNode<TContainer>, TypeParameterApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public void Add(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I convertedType, BoundGenericParameterTypeDefinition typeParameter)
        {
            Members.TypeParameters.Add(conversion, convertedType.TypeParameters, typeParameter);
        }

        public void Add(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I convertedType, List<BoundGenericParameterTypeDefinition> typeParameters)
        {
            Members.TypeParameters.Add(conversion, convertedType.TypeParameters, typeParameters);
        }

        public void Clear(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I convertedType)
        {
            Members.TypeParameters.Clear(conversion, convertedType.TypeParameters);
        }

        public BoundGenericParameterTypeDefinition_I Get(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I convertedType, string name)
        {
            return Members.TypeParameters.Get(conversion, convertedType.TypeParameters, name);
        }

        public BoundGenericParameterTypeDefinition_I Get(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I convertedType, int position)
        {
            return Members.TypeParameters.Get(conversion, convertedType.TypeParameters, position);
        }

        public string[] GetNames(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I convertedType)
        {
            return Members.TypeParameters.GetNames(conversion, convertedType.TypeParameters);
        }

        public BoundGenericParameterTypeDefinition_I GetOrThrow(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I convertedType, string name)
        {
            return Members.TypeParameters.GetOrThrow(conversion, convertedType.TypeParameters, name);
        }

        public BoundGenericParameterTypeDefinition_I GetOrThrow(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I convertedType, int position)
        {
            return Members.TypeParameters.GetOrThrow(conversion, convertedType.TypeParameters, position);
        }
    }
}
