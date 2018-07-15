using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types
{
	public interface CollectionApiMask_I
	{
		

		

		SemanticTypeMask_I Get(InfrastructureRuntimicModelMask_I semanticModel, TypeReference input);

		SemanticTypeDefinitionMask_I Get(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName);

		SemanticTypeMask_I GetOrThrow(InfrastructureRuntimicModelMask_I model, TypeDefinition typeDefinition);

		SemanticTypeMask_I GetOrThrow(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName);

		



		



		bool TryGet(InfrastructureRuntimicModelMask_I model, string resolutionName, out SemanticTypeDefinitionMask_I typeEntry);

		bool TryGet(InfrastructureRuntimicModelMask_I model, TypeReference input, out SemanticTypeDefinitionMask_I typeEntry);
		
	}
}
