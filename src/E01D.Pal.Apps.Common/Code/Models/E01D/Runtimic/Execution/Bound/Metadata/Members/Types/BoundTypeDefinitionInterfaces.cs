using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
    public class BoundTypeDefinitionInterfaces: BoundTypeDefinitionInterfacesMask_I
    {
        public Dictionary<string, SemanticInterfaceTypeMask_I> ByResolutionName { get; set; } =
            new Dictionary<string, SemanticInterfaceTypeMask_I>();
    }
}
