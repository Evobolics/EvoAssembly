using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public class UnifiedModelTypes: UnifiedModelTypesMask_I
	{
		public Dictionary<string, UnifiedTypeNodeSet> Sets { get; set; } = new Dictionary<string, UnifiedTypeNodeSet>();


	}
}
