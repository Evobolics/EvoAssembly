using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public interface SemanticModuleMask_I: Module_I
    {
        bool IsBuiltOut { get; }
        ModuleDefinition SourceModuleDefinition { get; }

        SemanticModuleTypes_I Types { get; }

        SemanticAssemblyMask_I Assembly { get; }
    }
}
