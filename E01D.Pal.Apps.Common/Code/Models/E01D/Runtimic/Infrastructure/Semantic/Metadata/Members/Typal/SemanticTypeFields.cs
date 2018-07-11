using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public class SemanticTypeFields: SemanticTypeFieldsMask_I
    {
        public Dictionary<string, SemanticFieldMask_I> ByName { get; set; } =
            new Dictionary<string, SemanticFieldMask_I>();
    }
}
