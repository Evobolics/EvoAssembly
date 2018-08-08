using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Metadata;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Unified;
using Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public class TypeApi<TContainer> : UnifiedApiNode<TContainer>, TypeApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

		public void Add(RuntimicSystemModel model, UnifiedTypeNode node)
		{
			//if (!model.Unified.Types.Sets.TryGetValue(node.ResolutionName, out UnifiedTypeNodeSet set))
			//{
			//	set = new UnifiedTypeNodeSet()
			//	{
			//		ResolutionName = node.ResolutionName
			//	};

			//	model.Unified.Types.Sets.Add(node.ResolutionName, set);
			//}

			//if (set.First == null)
			//{
			//	set.First = node;
			//	set.Last = node;
			//}
			//else
			//{
			//	set.Last.Next = node;
			//	set.Last = node;
			//}

			throw new System.NotImplementedException();

		}

		public void ExtendWithCrossReference(RuntimicSystemModel model, SemanticTypeDefinitionMask_I semanticType, string assemblyQualifiedNameCrossReferenceKey)
		{
			var resolutionName = Execution.Conversion.Metadata.Members.Types.Naming.GetResolutionName(semanticType);

			var orginalNode = Get(model, resolutionName);

			if (orginalNode == null)
			{
				throw new Exception("Could not find orginal node.  Could not add cross reference.");
			}

			//var entry = new UnifiedTypeNode()
			//{
			//	ResolutionName = assemblyQualifiedNameCrossReferenceKey,
			//	SourceTypeReference = semanticType.SourceTypeReference,
			//	AssemblyNode = orginalNode.AssemblyNode,
			//	ModuleNode = orginalNode.ModuleNode,
			//	SemanticType = semanticType,
			//};

			//Add(model, entry);


		}

		public bool IsAssociatedWithASecondaryNode(TypeReference typeReference)
		{
			return !(typeReference.IsByReference || typeReference.IsByReference || typeReference.IsByReference ||
			          typeReference.IsByReference);
		}

		/// <summary>
		/// Returns a unified type node from a type reference.  The unified type node can be a primary or secondary node
		/// depending on what type of type reference is the node.
		/// </summary>
		/// <param name="boundModel"></param>
		/// <param name="typeReference"></param>
		/// <returns></returns>
		public UnifiedTypeNode Ensure(RuntimicSystemModel boundModel, TypeReference typeReference)
		{
			// If the type reference is an external reference, then it needs to be resolved to a type reference that is associated with one of the loaded
			// assemblies prior to determining if the type reference needs to be treated as a converted type or a bound type.
			if (Cecil.Types.IsExternal(typeReference))
			{
				// came from bound
				//typeReference = Infrastructure.Models.Structural.Types.External.Resolve(boundModel, typeReference);
				throw new System.Exception("need to ensure the unified type is null.");
			}

			// Gets a module node via the Mvid
			var moduleNode = Unified.Modules.Ensure(boundModel, typeReference.Module);

			var moduleTypesNode = moduleNode.Types;

			var tableIndex = GetTableIndex(typeReference.MetadataToken.TokenType);

			var rowId = typeReference.MetadataToken.RID;

			// This is where the unified type node starts its journey.  
			//UnifiedTypeNode node = EnsureNodeAtTableRow(boundModel, moduleTypesNode, tableIndex, rowId);

			//moduleNode.Types.Tables[]
			throw new System.NotImplementedException();
		}

		private int GetTableIndex(TokenType tokenType)
		{
			switch (tokenType)
			{
				case TokenType.TypeDef:
				{
					return 0;
				}
				default:
				{
					throw new Exception("Table not setup yet.");
				}
			}
		}

		public UnifiedTypeNode Create(RuntimicSystemModel model, UnifiedAssemblyNode assemblyNode, UnifiedModuleNode moduleNode, TypeReference typeReference)
		{
			var resolutionName = GetResolutionName(typeReference);

			//return new UnifiedTypeNode()
			//{
			//	ResolutionName = resolutionName,
			//	AssemblyNode = assemblyNode,
			//	ModuleNode= moduleNode,
			//	SourceTypeReference = typeReference
			//};

			throw new System.NotImplementedException();
		}


		public UnifiedTypeNode Extend(RuntimicSystemModel model,UnifiedAssemblyNode assemblyNode, UnifiedModuleNode moduleNode, TypeReference typeReference)
		{
			var node = Create(model, assemblyNode, moduleNode, typeReference);

			Add(model, node);

			return node;
		}

		public UnifiedTypeNode Get(RuntimicSystemModel model, string resolutionName)
		{
			throw new System.NotImplementedException();

			//if (!model.Unified.Types.Sets.TryGetValue(resolutionName, out UnifiedTypeNodeSet set))
			//{
			//	return null;
			//}

			//if (set.First == set.Last)
			//{
			//	return set.First;
			//}
			//else
			//{
			//	throw new System.Exception("Multiple type nodes of the same name are not fully suppported yet.");
			//}
		}

		public string GetResolutionName(TypeReference typeReference)
		{
			return Cecil.Types.Naming.GetResolutionName(typeReference);
		}

		public void Update(RuntimicSystemModel semanticModel, SemanticTypeDefinitionMask_I semanticType)
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

			//if (node.SemanticType != null)
			//{
			//	throw new Exception("More than one add called.");
			//}

			//node.SemanticType = semanticType;

			throw new System.NotImplementedException();

		}






	}
}
