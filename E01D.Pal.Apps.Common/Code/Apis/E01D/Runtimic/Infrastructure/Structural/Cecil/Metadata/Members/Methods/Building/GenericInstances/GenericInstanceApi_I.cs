using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building.GenericInstances
{
	public interface GenericInstanceApi_I<TContainer> : GenericInstanceApiMask_I
	    where TContainer : RuntimicContainer_I<TContainer>
    {
	    new ClassApi_I<TContainer> Classes { get; set; }

	    new MethodApi_I<TContainer> Methods { get; set; }
	}
}
