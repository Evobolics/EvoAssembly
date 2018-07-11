using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
    public interface TypeParametersApi_I<TContainer> : TypeParametersApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
