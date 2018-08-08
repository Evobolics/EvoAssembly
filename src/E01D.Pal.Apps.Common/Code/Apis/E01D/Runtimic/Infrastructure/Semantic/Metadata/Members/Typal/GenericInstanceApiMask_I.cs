using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
	public interface GenericInstanceApiMask_I
	{
		TypeDefinition GetElementType(RuntimicSystemModel semanticModel, SemanticTypeDefinitionMask_I elementType);

		TypeDefinition GetElementType(RuntimicSystemModel model, GenericInstanceType genericInstanceType);
	}
}
