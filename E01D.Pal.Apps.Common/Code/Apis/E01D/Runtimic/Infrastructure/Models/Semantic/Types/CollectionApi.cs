using System;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types
{
	public class CollectionApi<TContainer> : BindingApiNode<TContainer>, CollectionApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void Add(InfrastructureModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType)
		{
			if (semanticType == null || semanticType.Module == null || semanticType.Module.Assembly == null)
			{
				throw new System.ArgumentNullException();
			}

			string resolutionName = Types.Naming.GetResolutionName(semanticType);



			if (resolutionName == "System.Diagnostics.Debug")
			{

			}

			TypeReference blueprintTypeDefintion = null;

			if (semanticType is SemanticGenericTypeDefinitionMask_I genericTypeDefinition)
			{
				blueprintTypeDefintion = genericTypeDefinition.GenericTypeDefinition;
			}

			if (!semanticModel.Semantic.Types.ByResolutionName.TryGetValue(resolutionName, out SemanticTypeDefinitionEntry entry))
			{
				entry = new SemanticTypeDefinitionEntry()
				{
					SourceTypeReference = semanticType.SourceTypeReference,
					ResolutionName = resolutionName,
					SourceAssemblyDefinition = semanticType.SourceModuleDefinition?.Assembly,
					SourceModuleDefinition = semanticType.SourceModuleDefinition,
					SemanticType = semanticType,
					BlueprintTypeDefintion = blueprintTypeDefintion
				};

				semanticModel.Semantic.Types.ByResolutionName.Add(entry.ResolutionName, entry);
			}
			else
			{
				if (entry.SemanticType != null)
				{
					throw new Exception("More than one add called.");
				}

				entry.SemanticType = semanticType;
				entry.BlueprintTypeDefintion = blueprintTypeDefintion;
			}
		}

		

		public SemanticTypeMask_I Get(InfrastructureModelMask_I semanticModel, TypeReference input)
		{
			string resolutionName = Types.Naming.GetResolutionName(input);

			return Get(semanticModel, resolutionName);
		}

		public SemanticTypeDefinitionMask_I Get(InfrastructureModelMask_I semanticModel, string resolutionName)
		{
			return Infrastructure.Models.Unified.Types.GetSemanticEntry(semanticModel, resolutionName)?.SemanticType;
		}

		

		public SemanticTypeMask_I GetOrThrow(InfrastructureModelMask_I model, TypeDefinition typeDefinition)
		{
			string resolutionName = Types.Naming.GetResolutionName(typeDefinition);

			return GetOrThrow(model, resolutionName);
		}

		public SemanticTypeMask_I GetOrThrow(InfrastructureModelMask_I semanticModel, string resolutionName)
		{
			var result = Get(semanticModel, resolutionName);

			if (result == null)
			{
				throw new System.Exception($"Could not resolve type '{resolutionName}'");
			}

			return result;
		}

		



		

		

		public bool TryGet(InfrastructureModelMask_I model, string resolutionName, out SemanticTypeDefinitionMask_I typeEntry)
		{
			typeEntry = Get(model, resolutionName);

			return typeEntry != null;
		}

		public bool TryGet(InfrastructureModelMask_I model, TypeReference input, out SemanticTypeDefinitionMask_I typeEntry)
		{
			string resolutionName = Types.Naming.GetResolutionName(input);

			return TryGet(model, resolutionName, out typeEntry);
		}

		public void AddCrossReference(InfrastructureModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType,
			string assemblyQualifiedNameCrossReferenceKey)
		{
			string resolutionName = Types.Naming.GetResolutionName(semanticType);

			if (!semanticModel.Semantic.Types.ByResolutionName.TryGetValue(resolutionName, out SemanticTypeDefinitionEntry orginalEntry))
			{
				throw new Exception("Could not find orginal node.  Could not add cross reference.");
			}

			var entry = new SemanticTypeDefinitionEntry()
			{
				ResolutionName = assemblyQualifiedNameCrossReferenceKey,
				SourceTypeReference = semanticType.SourceTypeReference,
				SourceAssemblyDefinition = orginalEntry.SourceAssemblyDefinition,
				SourceModuleDefinition = orginalEntry.SourceModuleDefinition,
				SemanticType = semanticType,
				BlueprintTypeDefintion = orginalEntry.BlueprintTypeDefintion
			};

			semanticModel.Semantic.Types.ByResolutionName.Add(assemblyQualifiedNameCrossReferenceKey, entry);

			
		}
	}
}
