using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public class ConvertedTypeDefinitionMethods: ConvertedTypeDefinitionMethodsMask_I
    {
        public Dictionary<string, List<SemanticMethodMask_I>> ByName { get; set; } =new Dictionary<string, List<SemanticMethodMask_I>>();
    }
}
