using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Models
{
    public interface ModelApi_I<TContainer> : ModelApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {

    }
}
