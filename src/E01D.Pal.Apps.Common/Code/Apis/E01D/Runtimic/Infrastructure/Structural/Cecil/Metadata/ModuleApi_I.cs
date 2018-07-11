using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
	public interface ModuleApi_I<TContainer> : ModuleApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
