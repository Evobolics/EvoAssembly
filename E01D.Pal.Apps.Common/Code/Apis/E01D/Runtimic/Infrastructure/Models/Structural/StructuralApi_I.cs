using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural
{
	public interface StructuralApi_I<TContainer> : StructuralApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
