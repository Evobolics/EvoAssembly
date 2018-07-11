using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface EnsuringApiMask_I
    {
        void EnsureTypes(InfrastructureModelMask_I semanticModel, SemanticModuleMask_I moduleEntry);
        object Ensure(InfrastructureModelMask_I semanticModel, SemanticModuleMask_I semanticModule, TypeReference input);
    }
}
