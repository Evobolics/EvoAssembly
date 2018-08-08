using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types
{
	public interface CollectionApiMask_I
	{
		

		

		SemanticTypeMask_I Get(RuntimicSystemModel semanticModel, TypeReference input);

		SemanticTypeDefinitionMask_I Get(RuntimicSystemModel semanticModel, string resolutionName);

		SemanticTypeMask_I GetOrThrow(RuntimicSystemModel model, TypeDefinition typeDefinition);

		SemanticTypeMask_I GetOrThrow(RuntimicSystemModel semanticModel, string resolutionName);

		



		



		bool TryGet(RuntimicSystemModel model, string resolutionName, out SemanticTypeDefinitionMask_I typeEntry);

		bool TryGet(RuntimicSystemModel model, TypeReference input, out SemanticTypeDefinitionMask_I typeEntry);
		
	}
}
