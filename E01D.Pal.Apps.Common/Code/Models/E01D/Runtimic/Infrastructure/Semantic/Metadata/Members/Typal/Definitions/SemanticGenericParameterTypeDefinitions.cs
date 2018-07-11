using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public class SemanticGenericParameterTypeDefinitions: SemanticGenericParameterTypeDefinitions_I
    {
        public List<SemanticGenericParameterTypeDefinitionMask_I> All { get; set; } =
            new List<SemanticGenericParameterTypeDefinitionMask_I>();

        public Dictionary<string, SemanticGenericParameterTypeDefinitionMask_I> ByName { get; set; } =
            new Dictionary<string, SemanticGenericParameterTypeDefinitionMask_I>();

        public Dictionary<int, SemanticGenericParameterTypeDefinitionMask_I> ByPosition { get; set; } =
            new Dictionary<int, SemanticGenericParameterTypeDefinitionMask_I>();
    }
}
