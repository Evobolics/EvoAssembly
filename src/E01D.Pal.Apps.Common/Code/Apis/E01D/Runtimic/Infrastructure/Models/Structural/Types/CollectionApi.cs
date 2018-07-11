using System;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural.Types
{
	public class CollectionApi<TContainer> : BindingApiNode<TContainer>, CollectionApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

		public void Add(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, ModuleDefinition module, TypeDefinition type)
		{
			string resolutionName = Types.Naming.GetResolutionName(type);

			if (!semanticModel.Semantic.Types.ByResolutionName.TryGetValue(resolutionName, out SemanticTypeDefinitionEntry entry)
			)
			{
				entry = new SemanticTypeDefinitionEntry()
				{
					ResolutionName = resolutionName,
					SourceTypeReference = type,
					SourceAssemblyDefinition = assemblyDefinition,
					SourceModuleDefinition = module
				};

				semanticModel.Semantic.Types.ByResolutionName.Add(resolutionName, entry);
			}
			else
			{
				throw new Exception("Trying to add more than once.");
			}
			


		}

		

		



		public TypeReference GetStoredTypeReference(InfrastructureModelMask_I model, TypeReference typeReference)
		{
			var resolutionName = Types.Naming.GetResolutionName(typeReference);

			return GetStoredTypeReference(model, resolutionName);
		}

		public TypeReference GetStoredTypeReference(InfrastructureModelMask_I model, Type genericTypeDefinitionType)
		{
			var fullName = Types.Naming.GetResolutionName(genericTypeDefinitionType);

			return GetStoredTypeReference(model, fullName);
		}

		public TypeReference GetStoredTypeReference(InfrastructureModelMask_I model, string fullName)
		{
			// Uses GetSemanticNode instead since this call can be made before the semantic type istself is created.
			// During semantic type creation, this call is made.
			var semanticNode = Infrastructure.Models.Unified.Types.GetSemanticEntry(model, fullName);

			return semanticNode?.SourceTypeReference;
		}

		public TypeReference GetStoredTypeReference(InfrastructureModelMask_I model, string fullName, out SemanticTypeDefinitionMask_I semanticType)
		{
			// Uses GetSemanticNode instead since this call can be made before the semantic type istself is created.
			// During semantic type creation, this call is made.
			var semanticNode = Infrastructure.Models.Unified.Types.GetSemanticEntry(model, fullName);

			semanticType = semanticNode?.SemanticType;

			return semanticNode?.SourceTypeReference;
		}


	}
}
