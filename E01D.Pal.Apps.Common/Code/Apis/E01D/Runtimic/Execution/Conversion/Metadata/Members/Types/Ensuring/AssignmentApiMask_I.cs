using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public interface AssignmentApiMask_I
    {
        void AssignInterfaces(ConvertedTypeDefinition target, List<SemanticTypeMask_I> interfaces);

        

        void AssignTypeParameters(ILConversion conversion, ConvertedTypeDefinition createdType, List<ConvertedGenericParameterTypeDefinition> typeParameters);

        void AssignGenericBlueprint(ConvertedTypeDefinition createdType, SemanticTypeDefinitionMask_I genericBlueprint);

        void AssignNestedTypes(ConvertedTypeDefinition createdType, Dictionary<string, SemanticTypeMask_I> nestedTypes);
    }
}
