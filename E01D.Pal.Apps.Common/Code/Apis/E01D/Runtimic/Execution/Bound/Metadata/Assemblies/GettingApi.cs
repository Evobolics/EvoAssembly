using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Assemblies
{
    public class GettingApi<TContainer> : BindingApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
       
    }
}
