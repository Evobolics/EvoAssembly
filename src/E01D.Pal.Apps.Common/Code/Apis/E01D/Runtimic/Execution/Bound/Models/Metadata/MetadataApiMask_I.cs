using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Metadata
{
	public interface MetadataApiMask_I
	{
		void Ensure(RuntimicSystemModel semanticModel, AssemblyDefinition assemblyDefinition, ModuleDefinition module, TypeDefinition type);
	}
}
