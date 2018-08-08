using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Unified;
using Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public class ExtendingApi<TContainer> : CecilApiNode<TContainer>, ExtendingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public UnifiedAssemblyNode Extend(RuntimicSystemModel runtimicSystem, AssemblyDefinition assemblyDefinition, List<UnifiedTypeNode> types)
		{
			var node = Unified.Assemblies.Extend(runtimicSystem, assemblyDefinition);

			Modules.Extend(runtimicSystem, node, types);

			return node;
		}
	}
}
