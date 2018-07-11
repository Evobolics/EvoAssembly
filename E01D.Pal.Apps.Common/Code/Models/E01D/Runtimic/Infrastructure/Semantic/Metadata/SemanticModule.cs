using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public class SemanticModule: SemanticMetadata, SemanticModule_I
    {
        public SemanticAssemblyMask_I Assembly { get; set; }

        public bool IsBuiltOut { get; set; }

        public ModuleDefinition SourceModuleDefinition { get; set; }
        public SemanticModuleTypes_I Types { get; set; } = new SemanticModuleTypes();
    }
}
