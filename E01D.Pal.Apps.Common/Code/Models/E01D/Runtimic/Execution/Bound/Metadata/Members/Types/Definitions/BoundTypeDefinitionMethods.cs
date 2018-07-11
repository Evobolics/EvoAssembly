using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
	public class BoundTypeDefinitionMethods : BoundTypeDefinitionMethodsMask_I
	{
		public Dictionary<string, List<SemanticMethodMask_I>> ByName { get; set; } = new Dictionary<string, List<SemanticMethodMask_I>>();
	}
}
