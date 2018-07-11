using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
	public interface CollectionApi_I<TContainer> : CollectionApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
