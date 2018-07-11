using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Constructors
{
    public interface ConstructorApi_I<TContainer>: ConstructorApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
