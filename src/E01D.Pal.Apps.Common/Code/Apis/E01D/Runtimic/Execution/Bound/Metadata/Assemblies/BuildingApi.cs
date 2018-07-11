using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
    public class BuildingApi<TContainer> : BindingApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        //public List<SemanticModuleMask_I> BuildOut(SemanticModelMask_I semanticModel, SemanticAssemblyMask_I semanticAssembly)
        //{
        //    return EnsureBuildOut(semanticModel, semanticAssembly, semanticAssembly.AssemblyDefinition);
        //}

        

        /// <summary>
        ///Ensures the assembly, modules and types are present.
        /// </summary>
        public SemanticAssemblyMask_I BuildOut(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition)
        {
            // Ensure the assembly
            var semanticAssembly = Assemblies.Ensuring.Ensure(semanticModel, assemblyDefinition);

            BuildOut(semanticModel, semanticAssembly);

            return semanticAssembly;
        }

        public void BuildOut(InfrastructureModelMask_I semanticModel, SemanticAssemblyMask_I semanticAssembly)
        {
            if (semanticAssembly.IsBuiltOut)
            {
                return;
            }

            if (!semanticAssembly.IsBound())
            {
                throw new System.NotImplementedException("Semantic assemblies not handled");
            }

            BoundAssembly_I boundAssembly = (BoundAssembly_I)semanticAssembly;

            var list = Modules.Ensuring.EnsureAll(semanticModel, boundAssembly);

            for (int i = 0; i < list.Count; i++)
            {
                var moduleEntry = list[i];

                Modules.Building.BuildOut(semanticModel, moduleEntry);
            }

            boundAssembly.IsBuiltOut = true;
        }

    }
}
