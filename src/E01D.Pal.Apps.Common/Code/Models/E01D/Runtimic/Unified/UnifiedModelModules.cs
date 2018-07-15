using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public class UnifiedModelModules: UnifiedModelModulesMask_I
	{
		public Dictionary<string, UnifiedModuleNodeSet> Sets { get; set; } = new Dictionary<string, UnifiedModuleNodeSet>();
	}
}
