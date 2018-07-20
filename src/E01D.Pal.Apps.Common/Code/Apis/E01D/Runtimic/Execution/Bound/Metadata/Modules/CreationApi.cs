using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
	public class CreationApi<TContainer> : BoundApiNode<TContainer>, CreationApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public BoundModule Create(SemanticAssemblyMask_I entry, ModuleDefinition moduleDefinition)
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
