using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
    public class TypeParametersApi<TContainer> : BoundApiNode<TContainer>, TypeParametersApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
