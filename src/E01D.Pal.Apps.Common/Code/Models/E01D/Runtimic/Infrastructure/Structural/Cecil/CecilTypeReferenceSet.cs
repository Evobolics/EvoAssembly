using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Cecil
{
	public class CecilTypeReferenceSet
	{
		public List<UnifiedTypeNode> Types { get; set; } = new List<UnifiedTypeNode>();

		public List<UnifiedAssemblyNode> Assemblies { get; set; } = new List<UnifiedAssemblyNode>();
	}
}
