using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models
{
    public interface ModelAssembliesApiMask_I
    {
	    SemanticAssemblyMask_I Get(InfrastructureRuntimicModelMask_I model, TypeReference typeReference);

		bool TryGet(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName, out SemanticAssemblyMask_I semanticAssemblyMask);
        
    }
}
