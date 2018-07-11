using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface SemanticTypeFieldsMask_I
    {
        Dictionary<string, SemanticFieldMask_I> ByName { get; set; }
    }
}
