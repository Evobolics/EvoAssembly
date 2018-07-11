using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public interface BoundGenericParameterTypeDefinitions_I: BoundGenericParameterTypeDefinitionsMask_I
    {
        new List<SemanticGenericParameterTypeDefinitionMask_I> All { get; set; }

        new Dictionary<string, SemanticGenericParameterTypeDefinitionMask_I> ByName { get; set; }

        new Dictionary<int, SemanticGenericParameterTypeDefinitionMask_I> ByPosition { get; set; }
    }
}
