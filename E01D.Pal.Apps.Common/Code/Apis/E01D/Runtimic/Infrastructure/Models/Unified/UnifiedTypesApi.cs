using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Unified
{
	public class UnifiedTypesApi<TContainer> : SemanticApiNode<TContainer>, UnifiedTypesApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

		public SemanticTypeDefinitionEntry GetSemanticEntry(InfrastructureModelMask_I semanticModel, string resolutionName)
		{
			if (semanticModel.Semantic.Types.ByResolutionName.TryGetValue(resolutionName, out SemanticTypeDefinitionEntry semanticNode))
			{
				return semanticNode;
			}

			return null;

		}
	}
}
