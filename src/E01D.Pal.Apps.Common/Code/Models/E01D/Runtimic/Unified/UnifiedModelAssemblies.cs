using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public class UnifiedModelAssemblies: UnifiedModelAssembliesMask_I
	{
		public Dictionary<string, UnifiedAssemblyNodeSet> Definitions { get; set; } = new Dictionary<string, UnifiedAssemblyNodeSet>();
	}
}
