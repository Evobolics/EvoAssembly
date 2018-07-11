using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Modules
{
    public interface EnsuringApiMask_I
    {
        SemanticModuleMask_I Ensure(InfrastructureModelMask_I semanticModel, TypeReference typeReference);
        List<SemanticModuleMask_I> EnsureAll(InfrastructureModelMask_I semanticModel, SemanticAssemblyMask_I semanticAssembly);
    }
}
