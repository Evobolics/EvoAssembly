using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public interface GettingApiMask_I
    {
	    SemanticModuleMask_I Get(InfrastructureRuntimicModelMask_I model, System.Type type);

	    SemanticModuleMask_I Get(InfrastructureRuntimicModelMask_I model, TypeReference typeReference);

	    SemanticModuleMask_I Get(InfrastructureRuntimicModelMask_I semanticModel, BoundAssemblyMask_I modulesAssembly, TypeReference typeReference);

    }
}
