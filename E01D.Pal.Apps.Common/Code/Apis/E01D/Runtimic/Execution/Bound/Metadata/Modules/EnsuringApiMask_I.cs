using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Modules
{
    public interface EnsuringApiMask_I
    {

        List<SemanticModuleMask_I> EnsureAll(InfrastructureModelMask_I semanticModel, SemanticAssemblyMask_I semanticAssembly);

        SemanticModuleMask_I Ensure(InfrastructureModelMask_I semanticModel, BoundAssembly_I semanticAssembly,
            ModuleDefinition moduleDefinition);

        
    }
}
