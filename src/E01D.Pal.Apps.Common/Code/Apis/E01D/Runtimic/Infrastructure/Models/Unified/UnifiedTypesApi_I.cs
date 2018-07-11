using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Unified
{
	public interface UnifiedTypesApi_I<TContainer> : UnifiedTypesApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
