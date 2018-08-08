using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public class UnifiedModelAssemblies: UnifiedModelAssembliesMask_I
	{
		/// <summary>
		/// 
		/// </summary>
		/// <notes>Assemblies are identified by an assembly qualified name.  Thus, the dictionary of assemblies remains.</notes>
		public Dictionary<string, UnifiedAssemblyNodeSet> Definitions { get; set; } = new Dictionary<string, UnifiedAssemblyNodeSet>();
	}
}
