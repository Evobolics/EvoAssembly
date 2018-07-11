using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public interface ConvertedModule_I:ConvertedMetadata_I, ConvertedModuleMask_I, ConvertedMetadataStore_I
    {
        new SemanticAssemblyMask_I Assembly { get; set; }

        new bool IsBuiltOut { get; set; }

        new ModuleBuilder ModuleBuilder { get; set; }

        new ModuleDefinition SourceModuleDefinition { get; set; }

        new ConvertedModuleTypes_I Types { get; set; } 
    }
}
