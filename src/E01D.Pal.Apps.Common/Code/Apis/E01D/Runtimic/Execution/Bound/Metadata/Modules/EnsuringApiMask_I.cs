using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public interface EnsuringApiMask_I
    {

        List<SemanticModuleMask_I> EnsureAll(InfrastructureRuntimicModelMask_I semanticModel, SemanticAssemblyMask_I semanticAssembly);

        SemanticModuleMask_I Ensure(InfrastructureRuntimicModelMask_I semanticModel, BoundAssembly_I semanticAssembly,
            ModuleDefinition moduleDefinition);

        
    }
}
