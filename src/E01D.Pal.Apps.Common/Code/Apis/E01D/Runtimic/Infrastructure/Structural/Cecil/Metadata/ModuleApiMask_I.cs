using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
	public interface ModuleApiMask_I
	{
		void Extend(StructuralRuntimicModelMask_I semanticModel, UnifiedAssemblyNode assemblyNode);

		void Extend(StructuralRuntimicModelMask_I semanticModel, UnifiedAssemblyNode assemblyNode, List<UnifiedTypeNode> types);
	}
}
