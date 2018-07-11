using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Constructors.Building
{
	public interface RuntimeCreatedApi_I<TContainer> : RuntimeCreatedApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
