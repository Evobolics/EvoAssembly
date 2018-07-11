using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building
{
	public interface RuntimeCreatedApi_I<TContainer> : RuntimeCreatedApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
