using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods
{
	public interface MethodApi_I<TContainer> : MethodApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		new BuildingApi_I<TContainer> Building { get; set; }

		new EnsuringApi_I<TContainer> Ensuring { get; set; }

		new GettingApi_I<TContainer> Getting { get; set; }
	}
}
