using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
	public class CreationApi<TContainer> : BoundApiNode<TContainer>, CreationApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public BoundModule Create(RuntimicSystemModel runtimicSystem, BoundModuleNode moduleNode)
        {
            

            var module = new BoundModule()
            {
                Assembly = moduleNode.AssemblyNode.BoundAssembly,
                ModuleNode = moduleNode
            };

            return module;
        }
    }
}
