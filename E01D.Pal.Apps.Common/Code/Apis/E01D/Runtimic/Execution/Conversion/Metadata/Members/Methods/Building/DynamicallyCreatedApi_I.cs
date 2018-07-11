using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building
{
	public interface DynamicallyCreatedApi_I<TContainer> : DynamicallyCreatedApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
