using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Semantic
{
    public interface SemanticModelTypesMask_I
    {
        Dictionary<string, SemanticTypeDefinitionEntry> ByResolutionName { get; set; }
    }
}
