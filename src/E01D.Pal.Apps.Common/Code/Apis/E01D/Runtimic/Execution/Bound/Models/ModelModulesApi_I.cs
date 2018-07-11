using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models
{
    public interface ModelModulesApi_I<TContainer> : ModelModulesApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {

    }
}
