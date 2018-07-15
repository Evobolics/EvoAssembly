using System;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types
{
	public class CollectionApi<TContainer> : BindingApiNode<TContainer>, CollectionApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

		

		public SemanticTypeMask_I Get(InfrastructureRuntimicModelMask_I semanticModel, TypeReference input)
		{
			string resolutionName = Types.Naming.GetResolutionName(input);

			return Get(semanticModel, resolutionName);
		}

		public SemanticTypeDefinitionMask_I Get(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName)
		{
			return Unified.Types.Get(semanticModel, resolutionName)?.SemanticType;
		}

		

		public SemanticTypeMask_I GetOrThrow(InfrastructureRuntimicModelMask_I model, TypeDefinition typeDefinition)
		{
			string resolutionName = Types.Naming.GetResolutionName(typeDefinition);

			return GetOrThrow(model, resolutionName);
		}

		public SemanticTypeMask_I GetOrThrow(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName)
		{
			var result = Get(semanticModel, resolutionName);

			if (result == null)
			{
				throw new System.Exception($"Could not resolve type '{resolutionName}'");
			}

			return result;
		}

		



		

		

		public bool TryGet(InfrastructureRuntimicModelMask_I model, string resolutionName, out SemanticTypeDefinitionMask_I typeEntry)
		{
			typeEntry = Get(model, resolutionName);

			return typeEntry != null;
		}

		public bool TryGet(InfrastructureRuntimicModelMask_I model, TypeReference input, out SemanticTypeDefinitionMask_I typeEntry)
		{
			string resolutionName = Types.Naming.GetResolutionName(input);

			return TryGet(model, resolutionName, out typeEntry);
		}

		
	}
}
