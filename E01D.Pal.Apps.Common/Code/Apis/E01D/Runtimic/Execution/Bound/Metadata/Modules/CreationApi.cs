using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Modules
{
	public class CreationApi<TContainer> : BindingApiNode<TContainer>, CreationApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public SemanticModuleMask_I CreateModuleEntry(SemanticAssemblyMask_I entry, ModuleDefinition moduleDefinition)
        {
            var name = moduleDefinition != null ? moduleDefinition.Name : entry.Name;

            var module = new BoundModule()
            {
                Name = name,
                Assembly = entry,
                SourceModuleDefinition = moduleDefinition
            };

            return module;
        }
    }
}
