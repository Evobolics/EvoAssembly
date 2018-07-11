using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface TypeApi_I<TContainer> : TypeApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
