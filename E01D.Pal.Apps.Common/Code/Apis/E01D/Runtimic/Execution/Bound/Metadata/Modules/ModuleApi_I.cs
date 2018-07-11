using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Modules
{
    public interface ModuleApi_I<TContainer> : ModuleApiMask_I
        where TContainer :RuntimicContainer_I<TContainer>
    {
        new CreationApi_I<TContainer> Creation { get; }


        new AdditionApi_I<TContainer> Addition { get; }
    }
}
