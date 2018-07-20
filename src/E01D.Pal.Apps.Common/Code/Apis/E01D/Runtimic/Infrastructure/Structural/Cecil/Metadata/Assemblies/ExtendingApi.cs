using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public class ExtendingApi<TContainer> : CecilApiNode<TContainer>, ExtendingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public UnifiedAssemblyNode Extend(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, List<UnifiedTypeNode> types)
		{
			var node = Unified.Assemblies.Extend(semanticModel, assemblyDefinition);

			Modules.Extend(semanticModel, node, types);

			return node;
		}
	}
}
