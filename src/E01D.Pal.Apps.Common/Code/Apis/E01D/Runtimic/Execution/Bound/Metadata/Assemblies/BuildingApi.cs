using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Modeling.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
    public class BuildingApi<TContainer> : BindingApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
		public void Build(InfrastructureRuntimicModelMask_I model, List<UnifiedAssemblyNode> referencedList)
		{
			for (int i = 0; i < referencedList.Count; i++)
			{
				var assemblyNode = referencedList[i];

				Build(model, assemblyNode);
			}
		}

	    

	    private BoundAssemblyMask_I Build(InfrastructureRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode)
	    {
		    var assemblyDefinition = assemblyNode.SourceAssemblyDefinition;

		    var assemblyQualifiedName = Cecil.Assemblies.Naming.GetAssemblyName(assemblyDefinition);

		    var assembly = Execution.Metadata.Assemblies.FindAssembly(assemblyQualifiedName);

			var boundAssembly = Assemblies.Creation.CreateAssemblyEntry(model, assemblyDefinition, assembly);

		    assemblyNode.Semantic = boundAssembly;

		    for (int i = 0; i < assemblyNode.ModuleNodes.Count; i++)
		    {
			    var moduleNode = assemblyNode.ModuleNodes[i];

			    var boundModule = Modules.Building.Build(model, moduleNode);

			    boundAssembly.Modules.Add(boundModule.Name, boundModule);

			}

		    return boundAssembly;

	    }


		/// <summary>
		///Ensures the assembly, modules and types are present.
		/// </summary>
		public SemanticAssemblyMask_I BuildOut(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition)
        {
            // Ensure the assembly
            var semanticAssembly = Assemblies.Ensuring.Ensure(semanticModel, assemblyDefinition);

            BuildOut(semanticModel, semanticAssembly);

            return semanticAssembly;
        }

        public void BuildOut(InfrastructureRuntimicModelMask_I semanticModel, SemanticAssemblyMask_I semanticAssembly)
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
