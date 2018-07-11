using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public class SemanticTypeDefinitionInterfaces: SemanticTypeDefinitionInterfacesMask_I
    {
        public Dictionary<string, SemanticInterfaceTypeMask_I> ByResolutionName { get; set; } =
            new Dictionary<string, SemanticInterfaceTypeMask_I>();
    }
}
