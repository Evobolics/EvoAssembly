using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Building.GenericInstances
{
	public interface Phase2DependencyBuildApi_I<TContainer> : Phase2DependencyBuildApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
