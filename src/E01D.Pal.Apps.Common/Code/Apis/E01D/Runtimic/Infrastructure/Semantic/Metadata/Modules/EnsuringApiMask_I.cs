using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Modules
{
    public interface EnsuringApiMask_I
    {
        SemanticModuleMask_I Ensure(InfrastructureRuntimicModelMask_I semanticModel, TypeReference typeReference);
        List<SemanticModuleMask_I> EnsureAll(InfrastructureRuntimicModelMask_I semanticModel, SemanticAssemblyMask_I semanticAssembly);
    }
}
