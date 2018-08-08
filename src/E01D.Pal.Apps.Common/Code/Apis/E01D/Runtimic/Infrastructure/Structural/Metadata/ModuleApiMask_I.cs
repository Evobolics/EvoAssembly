using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata
{
    public interface ModuleApiMask_I
    {
        StructuralModuleNode Ensure(RuntimicSystemModel runtimicSystem, StructuralAssemblyNode structuralAssemblyNode, Guid moduleVersionId);

        StructuralModuleNode Ensure(RuntimicSystemModel runtimicSystem, StructuralAssemblyNode structuralAssemblyNode, ModuleDefinition moduleDefinition);
        StructuralModuleNode Get(RuntimicSystemModel model, Guid moduleMvid);
    }
}
