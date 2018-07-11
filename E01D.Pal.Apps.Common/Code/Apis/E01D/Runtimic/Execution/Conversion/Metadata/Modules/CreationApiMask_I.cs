using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
    public interface CreationApiMask_I
    {


        SemanticModuleMask_I CreateModuleEntry(BoundAssemblyMask_I entry);

        SemanticModuleMask_I CreateModuleEntry(BoundAssemblyMask_I entry, ModuleDefinition moduleDefinition);
    }
}
