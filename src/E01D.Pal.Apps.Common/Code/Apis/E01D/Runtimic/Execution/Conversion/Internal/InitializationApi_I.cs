using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion
{
	public interface InitializationApi_I<TContainer> : InitializationApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{

	}
}
