using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public class EnsuringApi<TContainer> : BindingApiNode<TContainer>,EnsuringApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

	    

		

	    

	    public SemanticModuleMask_I EnsureModuleFromAssembly(InfrastructureModelMask_I semanticModel, System.Type type)
	    {
		    var resolutionName = Types.Naming.GetResolutionName(type);

		    var semanticType = Infrastructure.Models.Semantic.Types.Collection.Get(semanticModel, resolutionName);

		    if (semanticType == null)
		    {
			    throw new System.Exception($"Assembly ensure does not support scope '{resolutionName}'");
		    }

		    return semanticType.Module;
	    }

	    

		public List<SemanticModuleMask_I> EnsureAll(InfrastructureModelMask_I semanticModel, SemanticAssemblyMask_I semanticAssembly)
        {
            // Ensure the module definition is in the assemlby definition that is past, and has not been loaded twice.
            if (!semanticAssembly.IsSemantic() && !semanticAssembly.IsBound())
            {
                throw new System.Exception("The assembly should be semantic or bound.");
            }

            if (semanticAssembly.IsSemantic())
            {
                return Semantic.Metadata.Modules.Ensuring.EnsureAll(semanticModel, semanticAssembly);
            }

            var boundAssembly = (BoundAssembly_I) semanticAssembly;

            var modules = new List<SemanticModuleMask_I>();

            foreach (var moduleDefinition in boundAssembly.AssemblyDefinition.Modules)
            {
                var module = Ensure(semanticModel, boundAssembly, moduleDefinition);

                modules.Add(module);
            }

            return modules;
        }

        public SemanticModuleMask_I Ensure(InfrastructureModelMask_I semanticModel, BoundAssembly_I semanticAssembly, ModuleDefinition moduleDefinition)
        {
            // Ensure the module definition is in the assemlby definition that is past, and has not been loaded twice.
            if (moduleDefinition.Assembly != semanticAssembly.AssemblyDefinition)
            {
                throw new System.Exception("The modules assembly definition must be the same as the semantic assemlby's definition");
            }

            if (semanticAssembly.Modules.TryGetValue(moduleDefinition.Name, out SemanticModuleMask_I moduleEntry))
            {
                return moduleEntry;
            }

            moduleEntry = Modules.Creation.CreateModuleEntry(semanticAssembly, moduleDefinition);

            Modules.Addition.AddModule(moduleEntry);

            return moduleEntry;
        }
    }
}
