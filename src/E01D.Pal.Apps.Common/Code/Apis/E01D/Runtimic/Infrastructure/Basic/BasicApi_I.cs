using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Basic
{
	public interface BasicApi_I<TContainer> :BasicApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		new BasicTypesApi_I<TContainer> Types { get; set; }
	}
}
