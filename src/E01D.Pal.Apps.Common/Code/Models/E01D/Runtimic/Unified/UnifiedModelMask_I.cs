using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public interface UnifiedModelMask_I
	{
		UnifiedModelAssembliesMask_I Assemblies { get; }

		Dictionary<string, UnifiedArrayInstanceNodeSet> Arrays { get;  }

		UnifiedModelModulesMask_I Modules { get; }

		UnifiedModelTypesMask_I Types { get; }
	}
}
