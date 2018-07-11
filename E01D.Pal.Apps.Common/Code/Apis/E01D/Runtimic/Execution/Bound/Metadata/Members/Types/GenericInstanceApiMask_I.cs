using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
	public interface GenericInstanceApiMask_I
	{
		TypeDefinition GetElementType(InfrastructureModelMask_I semanticModel, BoundTypeDefinitionMask_I elementType);
	}
}
