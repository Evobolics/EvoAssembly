using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Basic
{
	public interface BasicTypesApi_I<TContainer> : BasicTypesApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
