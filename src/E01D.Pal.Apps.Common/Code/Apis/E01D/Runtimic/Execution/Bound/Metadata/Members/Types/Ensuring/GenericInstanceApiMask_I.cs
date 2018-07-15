using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
    public interface GenericInstanceApiMask_I
    {
	    SemanticTypeDefinitionMask_I Ensure(InfrastructureRuntimicModelMask_I semanticModel, BoundModule_I convertedModule, TypeReference input, BoundTypeDefinitionMask_I declaringType, System.Type type);

    }
}
