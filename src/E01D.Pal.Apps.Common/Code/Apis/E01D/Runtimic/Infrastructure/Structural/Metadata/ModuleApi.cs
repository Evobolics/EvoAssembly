using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata
{
    public class ModuleApi<TContainer> : RuntimeApiNode<TContainer>, ModuleApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public StructuralModuleNode Ensure(RuntimicSystemModel runtimicSystem,
            StructuralAssemblyNode structuralAssemblyNode, Guid moduleVersionId)
        {
            if (runtimicSystem.TypeSystems.Structural.Modules.ByVersionId.TryGetValue(moduleVersionId, out StructuralModuleNode moduleNode))
            {
                return moduleNode;
            }

            if (!Infrastructure.Structural.Cecil.Modules.Find(structuralAssemblyNode.CecilAssemblyDefinition, 
                moduleVersionId, out ModuleDefinition moduleDefinition))
            {
                throw new Exception($"Module definition was not found matching the module version id {moduleVersionId}");
            }

            return Ensure(runtimicSystem, structuralAssemblyNode, moduleDefinition);
        }

        public StructuralModuleNode Ensure(RuntimicSystemModel runtimicSystem, StructuralAssemblyNode structuralAssemblyNode,
            ModuleDefinition moduleDefinition)
        {
            var moduleNode = new StructuralModuleNode()
            {
                CecilModuleDefinition = moduleDefinition,
                VersionId = moduleDefinition.Mvid,
                Assembly = structuralAssemblyNode
            };

            runtimicSystem.TypeSystems.Structural.Modules.ByVersionId.Add(moduleDefinition.Mvid, moduleNode);

            structuralAssemblyNode.Modules.Add(moduleDefinition.Mvid, moduleNode);

            return moduleNode;
        }

        public StructuralModuleNode Get(RuntimicSystemModel model, Guid moduleMvid)
        {
            return model.TypeSystems.Structural.Modules.ByVersionId[moduleMvid];
        }
    }
}
