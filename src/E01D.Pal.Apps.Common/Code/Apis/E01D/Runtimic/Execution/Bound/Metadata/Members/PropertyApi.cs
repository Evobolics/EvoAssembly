using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members
{
	public class PropertyApi<TContainer> : BoundApiNode<TContainer>, PropertyApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
	}
}
