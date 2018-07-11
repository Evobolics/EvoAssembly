using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural
{
	public interface StructuralModulesApi_I<TContainer> : StructuralModulesApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
