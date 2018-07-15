using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
	public class ModuleApi<TContainer> : CecilApiNode<TContainer>, ModuleApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void Extend(StructuralRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode)
		{
			Extend(model, assemblyNode, null);
		}

		public void Extend(StructuralRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode, List<UnifiedTypeNode> types)
		{
			var assemblyDefinition = assemblyNode.SourceAssemblyDefinition;

			foreach (var moduleDefinition in assemblyDefinition.Modules)
			{
				var moduleNode = Unified.Modules.Extend(model, assemblyNode, moduleDefinition);

				Types.Extending.Extend(model, assemblyNode, moduleNode, types);
			}
		}

		
	}
}
