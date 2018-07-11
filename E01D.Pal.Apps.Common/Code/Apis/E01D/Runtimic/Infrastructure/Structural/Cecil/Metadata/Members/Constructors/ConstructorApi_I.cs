
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors
{
	public interface ConstructorApi_I<TContainer> : ConstructorApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

		new GettingApi_I<TContainer> Getting { get; set; }
	}
}
