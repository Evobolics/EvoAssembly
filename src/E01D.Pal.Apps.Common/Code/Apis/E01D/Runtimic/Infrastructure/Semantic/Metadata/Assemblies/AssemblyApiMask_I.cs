using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Assemblies
{
    public interface AssemblyApiMask_I
    {
        BuildingApiMask_I Building { get; }
        EnsuringApiMask_I Ensuring { get;  }

	    SemanticAssemblyMask_I Get(RuntimicSystemModel model, TypeReference typeReference);

	    SemanticAssemblyMask_I Get(RuntimicSystemModel model, string typeResolutionName);

	    bool TryGet(RuntimicSystemModel model, string resolutionName, out SemanticAssemblyMask_I semanticAssemblyMask);
	}
}
