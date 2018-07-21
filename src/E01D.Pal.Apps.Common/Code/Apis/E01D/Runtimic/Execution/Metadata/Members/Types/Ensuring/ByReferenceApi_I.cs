using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
	public interface ByReferenceApi_I<TContainer> : ByReferenceApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		
	}
}
