using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural
{
	public interface StructuralApiMask_I
	{
		CecilApiMask_I Cecil { get; }

		NamingApiMask_I Naming { get; }

	}
}
