using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface EventApi_I<TContainer>: EventApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
