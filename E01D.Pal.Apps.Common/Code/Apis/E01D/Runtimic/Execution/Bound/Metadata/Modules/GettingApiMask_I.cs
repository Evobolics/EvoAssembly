using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Modules
{
    public interface GettingApiMask_I
    {
	    SemanticModuleMask_I Get(InfrastructureModelMask_I model, System.Type type);

	    SemanticModuleMask_I Get(InfrastructureModelMask_I model, TypeReference typeReference);

	    SemanticModuleMask_I Get(InfrastructureModelMask_I semanticModel, BoundAssemblyMask_I modulesAssembly, TypeReference typeReference);

    }
}
