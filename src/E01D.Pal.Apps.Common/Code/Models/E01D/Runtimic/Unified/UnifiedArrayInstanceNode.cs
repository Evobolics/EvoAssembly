using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public class UnifiedArrayInstanceNode
	{
		public string ElementResolutionName { get; set; }

		

		public int Rank { get; set; }
		public SemanticTypeDefinitionMask_I SemanticType { get; set; }
	}
}
