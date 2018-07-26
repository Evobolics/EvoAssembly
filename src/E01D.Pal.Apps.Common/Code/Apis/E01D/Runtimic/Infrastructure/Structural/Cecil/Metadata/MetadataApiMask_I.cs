using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
	public interface MetadataApiMask_I
	{
		AssemblyApiMask_I Assemblies { get; }

		InstructionApiMask_I Instructions { get; }

		MemberApiMask_I Members { get; }

		ModuleApiMask_I Modules { get; }
	}
}
