using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundGenericParameterTypeDefinitions: BoundGenericParameterTypeDefinitions_I
    {
        public List<SemanticGenericParameterTypeDefinitionMask_I> All { get; set; } = new List<SemanticGenericParameterTypeDefinitionMask_I>();

        public Dictionary<string, SemanticGenericParameterTypeDefinitionMask_I> ByName { get; set; } = new Dictionary<string, SemanticGenericParameterTypeDefinitionMask_I>();

        public Dictionary<int, SemanticGenericParameterTypeDefinitionMask_I> ByPosition { get; set; } = new Dictionary<int, SemanticGenericParameterTypeDefinitionMask_I>();
    }
}
