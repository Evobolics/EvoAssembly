using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Models.Types
{
	public class CollectionApi<TContainer> : BindingApiNode<TContainer>, CollectionApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void Add(InfrastructureModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType)
		{
			Infrastructure.Models.Semantic.Types.Collection.Add(semanticModel, semanticType);
		}

		public SemanticTypeDefinitionMask_I Get(InfrastructureModelMask_I semanticModel, string resolutionName)
		{
			return Infrastructure.Models.Semantic.Types.Collection.Get(semanticModel, resolutionName);
		}

		public SemanticTypeMask_I Get(InfrastructureModelMask_I semanticModel, TypeReference input)
		{
			return Infrastructure.Models.Semantic.Types.Collection.Get(semanticModel, input);
		}

		public SemanticTypeMask_I GetOrThrow(InfrastructureModelMask_I semanticModel, string resolutionName)
		{
			return Infrastructure.Models.Semantic.Types.Collection.GetOrThrow(semanticModel, resolutionName);
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
	}
}
