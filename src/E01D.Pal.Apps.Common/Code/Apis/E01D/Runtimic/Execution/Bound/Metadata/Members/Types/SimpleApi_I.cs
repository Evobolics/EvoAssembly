using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
    public interface SimpleApi_I<TContainer> : SimpleApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
