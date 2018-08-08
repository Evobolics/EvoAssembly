using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural
{
	public interface StructuralApiMask_I
	{
		CecilApiMask_I Cecil { get; }

		MetadataApiMask_I Metadata { get; }

        NamingApiMask_I Naming { get; }

		Metadata.Members.Types.TypeApiMask_I Types { get; }

	}
}
