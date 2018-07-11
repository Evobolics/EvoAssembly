using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Models.Metadata
{
	public interface MetadataApiMask_I
	{
		void Ensure(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, ModuleDefinition module, TypeDefinition type);
	}
}
