using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public interface CreationApiMask_I
    {
        //List<BoundModuleMask_I> CreateModuleEntries(BoundAssemblyMask_I entry);

        //BoundModuleMask_I CreateModuleEntry(BoundAssemblyMask_I entry);

        //BoundModuleMask_I CreateModuleEntry(BoundAssemblyMask_I entry, ModuleDefinition moduleDefinition);

        SemanticModuleMask_I CreateModuleEntry(SemanticAssemblyMask_I boundAssembly, ModuleDefinition moduleDefinition);
    }
}
