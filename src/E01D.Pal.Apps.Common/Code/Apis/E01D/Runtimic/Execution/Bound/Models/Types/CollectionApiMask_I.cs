using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
	public interface CollectionApiMask_I
	{
		void Add(InfrastructureRuntimicModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType);

		bool TryGet(InfrastructureRuntimicModelMask_I model, TypeReference input, out SemanticTypeDefinitionMask_I typeEntry);

		SemanticTypeDefinitionMask_I Get(InfrastructureRuntimicModelMask_I semanticModel, string typeDefinitionFullName);

		SemanticTypeMask_I GetOrThrow(InfrastructureRuntimicModelMask_I semanticModel, string typeDefinitionFullName);
	}
}
