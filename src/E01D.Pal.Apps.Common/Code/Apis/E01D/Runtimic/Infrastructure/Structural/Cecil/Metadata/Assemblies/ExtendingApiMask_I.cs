using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Unified;
using Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public interface ExtendingApiMask_I
	{
		UnifiedAssemblyNode Extend(RuntimicSystemModel semanticModel, AssemblyDefinition assemblyDefinition, List<UnifiedTypeNode> types);
	}
}
