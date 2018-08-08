using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	public class BoundTypeTable
	{
		public Dictionary<uint, BoundTypeNode> ByRow { get; set; } = new Dictionary<uint, BoundTypeNode>();
	}
}
