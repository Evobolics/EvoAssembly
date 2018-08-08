using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Unified;
using Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Cecil
{
	public class CecilTypeReferenceSet
	{
		public List<UnifiedTypeNode> Types { get; set; } = new List<UnifiedTypeNode>();

		public List<UnifiedAssemblyNode> Assemblies { get; set; } = new List<UnifiedAssemblyNode>();
	}
}
