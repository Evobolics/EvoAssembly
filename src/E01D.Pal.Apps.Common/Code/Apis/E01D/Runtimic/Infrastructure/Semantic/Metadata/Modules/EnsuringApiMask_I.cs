using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Modules
{
    public interface EnsuringApiMask_I
    {
        SemanticModuleMask_I Ensure(RuntimicSystemModel semanticModel, TypeReference typeReference);
        List<SemanticModuleMask_I> EnsureAll(RuntimicSystemModel semanticModel, SemanticAssemblyMask_I semanticAssembly);
    }
}
