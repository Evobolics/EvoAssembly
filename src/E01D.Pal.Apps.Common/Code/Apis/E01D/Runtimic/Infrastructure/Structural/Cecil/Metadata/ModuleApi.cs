using System;
using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;
using Root.Code.Models.E01D.Runtimic.Unified;
using Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
	public class ModuleApi<TContainer> : CecilApiNode<TContainer>, ModuleApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void Extend(RuntimicSystemModel model, UnifiedAssemblyNode assemblyNode)
		{
			Extend(model, assemblyNode, null);
		}

		public void Extend(RuntimicSystemModel model, UnifiedAssemblyNode assemblyNode, List<UnifiedTypeNode> types)
		{
			var assemblyDefinition = assemblyNode.SourceAssemblyDefinition;

			foreach (var moduleDefinition in assemblyDefinition.Modules)
			{
				var moduleNode = Unified.Modules.Extend(model, assemblyNode, moduleDefinition);

				Types.Extending.Extend(model, assemblyNode, moduleNode, types);
			}
		}

		public StructuralModuleNode Ensure(RuntimicSystemModel runtimicSystem, StructuralAssemblyNode structuralAssemblyNode, Guid versionId)
		{
			throw new NotImplementedException();
		}

		public bool Find(AssemblyDefinition assemblyDefinition, Guid moduleVersionId, out ModuleDefinition moduleDefinition)
		{
			for (int i = 0; i < assemblyDefinition.Modules.Count; i++)
			{
				var module = assemblyDefinition.Modules[i];

				if (module.Mvid == moduleVersionId)
				{
					moduleDefinition = module;

					return true;
				}
			}

			moduleDefinition = null;

			return false;
		}
	}
}
