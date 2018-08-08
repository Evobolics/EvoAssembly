using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public interface EnsuringApiMask_I
    {

        List<SemanticModuleMask_I> EnsureAll(RuntimicSystemModel semanticModel, SemanticAssemblyMask_I semanticAssembly);

        SemanticModuleMask_I Ensure(RuntimicSystemModel semanticModel, BoundAssembly_I semanticAssembly,
            ModuleDefinition moduleDefinition);


        BoundModuleNode EnsureNode(RuntimicSystemModel contextRuntimicSystem, BoundAssemblyNode boundAssembly, StructuralModuleNode module);
    }
}
