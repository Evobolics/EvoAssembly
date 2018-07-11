using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Models
{
    public interface AdditionApi_I<TContainer> : AdditionApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
