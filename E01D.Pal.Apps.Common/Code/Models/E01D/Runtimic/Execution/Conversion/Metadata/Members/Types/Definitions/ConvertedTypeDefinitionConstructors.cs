using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public class ConvertedTypeDefinitionConstructors: ConvertedTypeDefinitionConstructors_I
    {
        public List<SemanticConstructorMask_I> All { get; set; } = new List<SemanticConstructorMask_I>();
    }
}
