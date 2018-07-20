using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
    public interface GettingApiMask_I
    {
        

        SemanticTypeMask_I Get(InfrastructureRuntimicModelMask_I semanticModel, SemanticModuleMask_I module, TypeReference input);
    }
}
