using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
	public class BoundTypeDefinitionEvents: SemanticTypeEventsMask_I
	{
		public Dictionary<string, List<SemanticEventMask_I>> ByName { get; } =
			new Dictionary<string, List<SemanticEventMask_I>>();
	}
}
