using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.JustInTime
{
    public interface JustInTimeApi_I<TContainer> : JustInTimeApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
