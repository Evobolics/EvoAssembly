using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public class TypeApi<TContainer> : UnifiedApiNode<TContainer>, TypeApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

		public void Add(UnifiedRuntimicModelMask_I model, UnifiedTypeNode node)
		{
			if (!model.Unified.Types.Sets.TryGetValue(node.ResolutionName, out UnifiedTypeNodeSet set))
			{
				set = new UnifiedTypeNodeSet()
				{
					ResolutionName = node.ResolutionName
				};

				model.Unified.Types.Sets.Add(node.ResolutionName, set);
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


		}

		public void ExtendWithCrossReference(UnifiedRuntimicModelMask_I model, SemanticTypeDefinitionMask_I semanticType, string assemblyQualifiedNameCrossReferenceKey)
		{
			var resolutionName = Execution.Conversion.Metadata.Members.Types.Naming.GetResolutionName(semanticType);

			var orginalNode = Get(model, resolutionName);

			if (orginalNode == null)
			{
				throw new Exception("Could not find orginal node.  Could not add cross reference.");
			}

			var entry = new UnifiedTypeNode()
			{
				ResolutionName = assemblyQualifiedNameCrossReferenceKey,
				SourceTypeReference = semanticType.SourceTypeReference,
				AssemblyNode = orginalNode.AssemblyNode,
				ModuleNode = orginalNode.ModuleNode,
				SemanticType = semanticType,
			};

			Add(model, entry);


		}

		public UnifiedTypeNode Create(UnifiedRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode, UnifiedModuleNode moduleNode, TypeReference typeReference)
		{
			var resolutionName = GetResolutionName(typeReference);

			return new UnifiedTypeNode()
			{
				ResolutionName = resolutionName,
				AssemblyNode = assemblyNode,
				ModuleNode= moduleNode,
				SourceTypeReference = typeReference
			};
		}


		public UnifiedTypeNode Extend(UnifiedRuntimicModelMask_I model,UnifiedAssemblyNode assemblyNode, UnifiedModuleNode moduleNode, TypeReference typeReference)
		{
			var node = Create(model, assemblyNode, moduleNode, typeReference);

			Add(model, node);

			return node;
		}

		public UnifiedTypeNode Get(UnifiedRuntimicModelMask_I model, string resolutionName)
		{
			if (!model.Unified.Types.Sets.TryGetValue(resolutionName, out UnifiedTypeNodeSet set))
			{
				return null;
			}

			if (set.First == set.Last)
			{
				return set.First;
			}
			else
			{
				throw new System.Exception("Multiple type nodes of the same name are not fully suppported yet.");
			}
		}

		public string GetResolutionName(TypeReference typeReference)
		{
			return Cecil.Types.Naming.GetResolutionName(typeReference);
		}

		public void Update(UnifiedRuntimicModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType)
		{
			if (semanticType == null || semanticType.Module == null || semanticType.Module.Assembly == null)
			{
				throw new System.ArgumentNullException();
			}
			
			var resolutionName = Execution.Conversion.Metadata.Members.Types.Naming.GetResolutionName(semanticType);

			//var resolutionName2 = resolutionName.Replace("+", "/");

			var node = Get(semanticModel, resolutionName);

			//var node2 = Get(semanticModel, resolutionName2);

			if (node == null)
			{
				throw new Exception("Expected an existing node.");
			}

			if (node.SemanticType != null)
			{
				throw new Exception("More than one add called.");
			}

			node.SemanticType = semanticType;

		}






	}
}
