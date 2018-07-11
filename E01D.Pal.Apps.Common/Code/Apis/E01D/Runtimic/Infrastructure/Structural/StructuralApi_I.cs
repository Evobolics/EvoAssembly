using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural
{
	public interface StructuralApi_I<TContainer> : StructuralApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
		new CecilApi_I<TContainer> Cecil { get; set; }

		new NamingApi_I<TContainer> Naming { get; set; }
	}
}
