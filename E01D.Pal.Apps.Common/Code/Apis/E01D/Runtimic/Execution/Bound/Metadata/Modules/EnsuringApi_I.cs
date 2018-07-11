using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Modules
{
    public interface EnsuringApi_I<TContainer> : EnsuringApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    
    }
}
