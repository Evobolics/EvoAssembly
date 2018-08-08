using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models
{
    public interface ModelAssembliesApiMask_I
    {
	    SemanticAssemblyMask_I Get(RuntimicSystemModel model, TypeReference typeReference);

		bool TryGet(RuntimicSystemModel semanticModel, string resolutionName, out SemanticAssemblyMask_I semanticAssemblyMask);
        
    }
}
