using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.GenericInstances
{
	public interface Phase0PreSearchBuildApi_I<TContainer> : Phase0PreSearchBuildApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
