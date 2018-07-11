using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Unified
{
	public interface UnifiedApi_I<TContainer> :UnifiedApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		new UnifiedTypesApi_I<TContainer> Types { get; set; }
	}
}
