using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public interface ArrayApi_I<TContainer> : ArrayApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
