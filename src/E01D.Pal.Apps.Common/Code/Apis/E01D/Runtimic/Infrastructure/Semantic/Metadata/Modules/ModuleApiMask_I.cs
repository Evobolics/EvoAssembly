using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Modules
{
    public interface ModuleApiMask_I
    {
        BuildingApiMask_I Building { get; }
        EnsuringApiMask_I Ensuring { get;  }
	    void Get(InfrastructureRuntimicModelMask_I model, object semanticAssembly, TypeReference typeReference);
    }
}
