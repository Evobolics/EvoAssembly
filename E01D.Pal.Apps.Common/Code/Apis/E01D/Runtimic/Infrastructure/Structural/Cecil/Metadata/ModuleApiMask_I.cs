using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
	public interface ModuleApiMask_I
	{
		void Load(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition);
	}
}
