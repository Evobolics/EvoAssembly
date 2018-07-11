using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeArguments
{
	public interface BuildingApi_I<TContainer> : BuildingApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
