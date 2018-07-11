using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
	public interface GenericInstanceApi_I<TContainer> : GenericInstanceApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
