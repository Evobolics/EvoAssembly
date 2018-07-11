using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
    public interface GenericParameterApiMask_I
    {
	    SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I conversion, SemanticModuleMask_I module, TypeReference typeReference);

    }
}
