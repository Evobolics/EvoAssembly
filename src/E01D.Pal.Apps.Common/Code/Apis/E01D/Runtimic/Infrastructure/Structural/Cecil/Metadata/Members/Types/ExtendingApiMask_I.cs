using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Unified;
using Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface ExtendingApiMask_I
	{
		void Extend(RuntimicSystemModel model, UnifiedAssemblyNode assemblyNode,
			UnifiedModuleNode moduleNode, List<UnifiedTypeNode> types);

		UnifiedTypeNode Extend(RuntimicSystemModel model, UnifiedAssemblyNode assemblyNode,
			UnifiedModuleNode moduleNode, TypeReference typeReference, List<UnifiedTypeNode> types);
	}
}
