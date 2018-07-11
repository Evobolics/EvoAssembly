using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public class ConvertedTypeDefinitionProperties: ConvertedTypeDefinitionPropertiesMask_I
    {
	    public Dictionary<string, List<SemanticPropertyMask_I>> ByName { get; set; } =
		    new Dictionary<string, List<SemanticPropertyMask_I>>();
    }
}
