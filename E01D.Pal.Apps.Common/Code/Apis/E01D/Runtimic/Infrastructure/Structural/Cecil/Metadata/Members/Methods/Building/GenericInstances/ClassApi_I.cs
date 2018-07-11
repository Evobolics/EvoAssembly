using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building.GenericInstances
{
	public interface ClassApi_I<TContainer> : ClassApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
