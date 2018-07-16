using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members
{
	public class LocalApi<TContainer> : BoundApiNode<TContainer>, LocalApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
	}
}
