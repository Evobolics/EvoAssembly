using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members
{
	public class EventApi<TContainer> : BindingApiNode<TContainer>, EventApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
	}
}
