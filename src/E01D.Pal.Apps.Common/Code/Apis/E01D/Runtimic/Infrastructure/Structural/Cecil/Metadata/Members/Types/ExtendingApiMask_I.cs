using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface ExtendingApiMask_I
	{
		void Extend(StructuralRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode,
			UnifiedModuleNode moduleNode, List<UnifiedTypeNode> types);

		UnifiedTypeNode Extend(StructuralRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode,
			UnifiedModuleNode moduleNode, TypeReference typeReference, List<UnifiedTypeNode> types);
	}
}
