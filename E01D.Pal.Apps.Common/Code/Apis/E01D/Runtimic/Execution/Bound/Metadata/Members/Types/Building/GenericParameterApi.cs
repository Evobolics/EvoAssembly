using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Building
{
    public class GenericParameterApi<TContainer> : BindingApiNode<TContainer>, GenericParameterApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        
    }
}
