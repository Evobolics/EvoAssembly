using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public class ConvertedTypeDefinitionFields: SemanticTypeFieldsMask_I
    {
        public Dictionary<string, SemanticFieldMask_I> ByName { get; set; } =
            new Dictionary<string, SemanticFieldMask_I>();
    }
}
