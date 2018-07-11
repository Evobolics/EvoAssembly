using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
    public interface ModuleApi_I<TContainer> : ModuleApiMask_I
        where TContainer :RuntimicContainer_I<TContainer>
    {
        new AdditionApi_I<TContainer> Addition { get; }

        new EnsuringApi_I<TContainer> Ensuring { get; }

        new CreationApi_I<TContainer> Creation { get; }


        
    }
}
