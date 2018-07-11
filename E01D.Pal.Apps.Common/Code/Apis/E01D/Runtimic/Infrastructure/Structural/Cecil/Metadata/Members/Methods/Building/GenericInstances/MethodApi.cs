using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building.GenericInstances
{
	public class MethodApi<TContainer> : CecilApiNode<TContainer>, MethodApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		
	}
}
