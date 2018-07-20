using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public class ExtendingApi<TContainer> : CecilApiNode<TContainer>, ExtendingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void Extend(StructuralRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode, UnifiedModuleNode moduleNode, List<UnifiedTypeNode> types)
		{
			var moduleDefinition = moduleNode.ModuleDefinition;

			foreach (var typeDefinition in moduleDefinition.Types)
			{
				var node = Extend(model, assemblyNode, moduleNode, typeDefinition, types);

				
			}
		}

		public UnifiedTypeNode Extend(StructuralRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode, UnifiedModuleNode moduleNode, TypeReference typeReference, List<UnifiedTypeNode> types)
		{
			var unifiedTypeNode = Unified.Types.Extend(model, assemblyNode, moduleNode, typeReference);

			types?.Add(unifiedTypeNode);

			if (!(typeReference is TypeDefinition typeDefinition)) return unifiedTypeNode;

			if (!typeDefinition.HasNestedTypes) return unifiedTypeNode;

			foreach (var nestedType in typeDefinition.NestedTypes)
			{
				Extend(model, assemblyNode, moduleNode, nestedType, types);
			}

			return unifiedTypeNode;
		}
	}
}
