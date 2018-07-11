using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Ensuring
{
    public interface ArrayApiMask_I
    {
		SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, BoundModule_I boundModule, TypeReference input, BoundTypeDefinitionMask_I declaringType, System.Type underlyingType);
	}
}
