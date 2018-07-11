using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
	public class BoundTypeDefinitionProperties: SemanticTypePropertiesMask_I
	{
		public Dictionary<string, List<SemanticPropertyMask_I>> ByName { get; set; } =
			new Dictionary<string, List<SemanticPropertyMask_I>>();
	}
}
