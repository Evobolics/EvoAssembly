using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface SemanticTypeMethodsMask_I
    {
        Dictionary<string, List<SemanticMethodMask_I>> ByName { get; set; }
    }
}
