using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface EnsuringApiMask_I
    {
        void EnsureTypes(RuntimicSystemModel semanticModel, SemanticModuleMask_I moduleEntry);
        object Ensure(RuntimicSystemModel semanticModel, SemanticModuleMask_I semanticModule, TypeReference input);
    }
}
