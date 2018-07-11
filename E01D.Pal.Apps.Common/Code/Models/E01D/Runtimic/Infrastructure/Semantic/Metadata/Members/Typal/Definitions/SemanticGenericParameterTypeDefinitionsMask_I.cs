using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public interface SemanticGenericParameterTypeDefinitionsMask_I
    {
        List<SemanticGenericParameterTypeDefinitionMask_I> All { get; }

        Dictionary<string, SemanticGenericParameterTypeDefinitionMask_I> ByName { get; }

        Dictionary<int, SemanticGenericParameterTypeDefinitionMask_I> ByPosition { get; }
    }
}
