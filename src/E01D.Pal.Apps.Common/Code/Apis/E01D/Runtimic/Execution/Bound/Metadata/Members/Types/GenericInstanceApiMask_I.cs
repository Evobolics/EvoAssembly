using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	public interface GenericInstanceApiMask_I
	{
		TypeDefinition GetElementType(InfrastructureRuntimicModelMask_I semanticModel, BoundTypeDefinitionMask_I elementType);
	}
}
