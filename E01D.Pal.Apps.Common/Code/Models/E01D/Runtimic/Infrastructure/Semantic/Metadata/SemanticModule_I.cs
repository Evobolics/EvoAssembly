using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public interface SemanticModule_I: SemanticModuleMask_I
    {
        new SemanticAssemblyMask_I Assembly { get; set; }

        new bool IsBuiltOut { get; set; }

        new ModuleDefinition SourceModuleDefinition { get; set; }
    }
}
