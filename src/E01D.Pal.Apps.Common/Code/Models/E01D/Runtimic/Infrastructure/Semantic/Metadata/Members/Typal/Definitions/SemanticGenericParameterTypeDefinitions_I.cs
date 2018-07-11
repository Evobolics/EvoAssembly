using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public interface SemanticGenericParameterTypeDefinitions_I: SemanticGenericParameterTypeDefinitionsMask_I
    {
        new List<SemanticGenericParameterTypeDefinitionMask_I> All { get; set; }

        new Dictionary<string, SemanticGenericParameterTypeDefinitionMask_I> ByName { get; set; }

        new Dictionary<int, SemanticGenericParameterTypeDefinitionMask_I> ByPosition { get; set; }
    }
}
