using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public class ConvertedTypeDefinitionEvents: ConvertedTypeDefinitionEventsMask_I
    {
	    public Dictionary<string, List<SemanticEventMask_I>> ByName { get; } =
		    new Dictionary<string, List<SemanticEventMask_I>>();
	}
}
