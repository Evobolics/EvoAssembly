using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic
{
	public interface IdentificationApi_I<TContainer> : Api_I<TContainer>, IdentificationApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
