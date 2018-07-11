using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface LocalApi_I<TContainer>: LocalApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
