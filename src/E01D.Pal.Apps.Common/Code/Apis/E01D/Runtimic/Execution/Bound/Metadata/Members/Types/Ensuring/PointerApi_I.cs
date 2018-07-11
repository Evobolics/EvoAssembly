using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
	public interface PointerApi_I<TContainer> : PointerApiMask_I
		where TContainer : RuntimicContainer_I<TContainer> 
	{
	}
}
