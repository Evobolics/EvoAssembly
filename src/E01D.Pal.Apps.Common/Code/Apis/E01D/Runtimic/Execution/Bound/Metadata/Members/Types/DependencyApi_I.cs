using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	public interface DependencyApi_I<TContainer> : DependencyApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
		
	}
}
