using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
    public interface TypeParameterApiMask_I
    {
        void Add(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I type, BoundGenericParameterTypeDefinition typeParameter);

        void Add(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I type, List<BoundGenericParameterTypeDefinition> typeParameters);

        void Clear(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I type);

        BoundGenericParameterTypeDefinition_I Get(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I type, string name);

        BoundGenericParameterTypeDefinition_I Get(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I type, int position);

        string[] GetNames(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I convertedType);

        BoundGenericParameterTypeDefinition_I GetOrThrow(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I type, string name);

        BoundGenericParameterTypeDefinition_I GetOrThrow(SemanticModelMask_I conversion, BoundTypeDefinitionWithTypeParameters_I type, int position);


        
    }
}
