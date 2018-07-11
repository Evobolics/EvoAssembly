using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Building.NonGenericInstances
{
	public interface Phase0PreSearchBuildApi_I<TContainer> : Phase0PreSearchBuildApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
