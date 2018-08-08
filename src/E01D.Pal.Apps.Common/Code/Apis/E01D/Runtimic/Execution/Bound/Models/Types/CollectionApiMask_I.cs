using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
	public interface CollectionApiMask_I
	{
		void Add(RuntimicSystemModel semanticModel, SemanticTypeDefinitionMask_I semanticType);

		bool TryGet(RuntimicSystemModel model, TypeReference input, out SemanticTypeDefinitionMask_I typeEntry);

		SemanticTypeDefinitionMask_I Get(RuntimicSystemModel semanticModel, string typeDefinitionFullName);

		SemanticTypeMask_I GetOrThrow(RuntimicSystemModel semanticModel, string typeDefinitionFullName);
	}
}
