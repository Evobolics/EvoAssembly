using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata
{
	public class StructuralTypeTable
	{
		public Dictionary<uint, StructuralTypeNode> ByRow { get; set; } = new Dictionary<uint, StructuralTypeNode>();
	}
}
