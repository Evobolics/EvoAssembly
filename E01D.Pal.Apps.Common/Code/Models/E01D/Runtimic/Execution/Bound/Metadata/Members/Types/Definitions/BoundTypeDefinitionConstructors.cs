using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
	public class BoundTypeDefinitionConstructors: SemanticTypeConstructorsMask_I
	{
		public List<SemanticConstructorMask_I> All { get; } = new List<SemanticConstructorMask_I>();
	}
}
