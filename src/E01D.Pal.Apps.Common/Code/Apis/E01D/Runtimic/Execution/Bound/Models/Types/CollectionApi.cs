using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
	public class CollectionApi<TContainer> : BoundApiNode<TContainer>, CollectionApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void Add(InfrastructureRuntimicModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType)
		{
			Unified.Types.Update(semanticModel, semanticType);
		}

		public SemanticTypeDefinitionMask_I Get(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName)
		{
			return Infrastructure.Models.Semantic.Types.Collection.Get(semanticModel, resolutionName);
		}

		public SemanticTypeMask_I Get(InfrastructureRuntimicModelMask_I semanticModel, TypeReference input)
		{
			return Infrastructure.Models.Semantic.Types.Collection.Get(semanticModel, input);
		}

		public SemanticTypeMask_I GetOrThrow(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName)
		{
			return Infrastructure.Models.Semantic.Types.Collection.GetOrThrow(semanticModel, resolutionName);
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
