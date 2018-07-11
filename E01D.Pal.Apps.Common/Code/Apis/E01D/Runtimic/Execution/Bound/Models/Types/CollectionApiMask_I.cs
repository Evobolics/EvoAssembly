using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Models.Types
{
	public interface CollectionApiMask_I
	{
		void Add(InfrastructureModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType);

		bool TryGet(InfrastructureModelMask_I model, TypeReference input, out SemanticTypeDefinitionMask_I typeEntry);

		SemanticTypeDefinitionMask_I Get(InfrastructureModelMask_I semanticModel, string typeDefinitionFullName);

		SemanticTypeMask_I GetOrThrow(InfrastructureModelMask_I semanticModel, string typeDefinitionFullName);
	}
}
