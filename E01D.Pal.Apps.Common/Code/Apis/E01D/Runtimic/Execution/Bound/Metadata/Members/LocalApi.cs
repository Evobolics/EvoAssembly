using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members
{
	public class LocalApi<TContainer> : BindingApiNode<TContainer>, LocalApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
	}
}
