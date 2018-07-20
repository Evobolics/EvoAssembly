using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public interface GettingApiMask_I
    {
	    SemanticModuleMask_I Get(BoundRuntimicModelMask_I model, System.Type type);

	    SemanticModuleMask_I Get(BoundRuntimicModelMask_I model, TypeReference typeReference);

	    SemanticModuleMask_I Get(BoundRuntimicModelMask_I semanticModel, BoundAssemblyMask_I modulesAssembly, TypeReference typeReference);

    }
}
