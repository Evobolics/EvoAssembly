using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Models.Types
{
    public class TypeParametersApi<TContainer> : BindingApiNode<TContainer>, TypeParametersApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
