using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	public interface GenericInstanceApiMask_I
	{
		TypeDefinition GetElementType(RuntimicSystemModel semanticModel, BoundTypeDefinitionMask_I elementType);
	}
}
