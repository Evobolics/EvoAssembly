using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public class ModuleApi<TContainer> : UnifiedApiNode<TContainer>, ModuleApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void Add(UnifiedRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode, UnifiedModuleNode node)
		{
			if (!model.Unified.Modules.Sets.TryGetValue(node.Name, out UnifiedModuleNodeSet set))
			{
				set = new UnifiedModuleNodeSet()
				{
					Name = node.Name
				};

				model.Unified.Modules.Sets.Add(node.Name, set);
			}

			if (set.First == null)
			{
				set.First = node;
				set.Last = node;
			}
			else
			{
				set.Last.Next = node;
				set.Last = node;
			}

			assemblyNode.ModuleNodes.Add(node);
		}

		public UnifiedModuleNode Create(UnifiedRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode, ModuleDefinition moduleDefinition)
		{
			var resolutionName = GetResolutionName(moduleDefinition);

			return new UnifiedModuleNode()
			{
				Name = resolutionName,
				AssemblyNode = assemblyNode,
				ModuleDefinition = moduleDefinition
			};
		}


		public UnifiedModuleNode Extend(UnifiedRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode, ModuleDefinition moduleDefinition)
		{
			var node = Create(model, assemblyNode, moduleDefinition);

			Add(model, assemblyNode, node);

			return node;
		}

		public UnifiedModuleNode Get(InfrastructureRuntimicModelMask_I model, string moduleName)
		{
			if (!model.Unified.Modules.Sets.TryGetValue(moduleName, out UnifiedModuleNodeSet set))
			{
				return null;
			}

			if (set.First == set.Last)
			{
				return set.First;
			}
			else
			{
				throw new System.Exception("Multiple module nodes of the same name are not fully suppported yet.");
			}
		}

		public string GetResolutionName(ModuleDefinition moduleDefinition)
		{
			return moduleDefinition.Name;
		}
	}
}
