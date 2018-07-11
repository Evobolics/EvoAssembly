using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural.Types;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural
{
	public interface StructuralApiMask_I
	{
		StructuralModulesApiMask_I Modules { get; }

		StructuralTypesApiMask_I Types { get; }

		void AddAssemblyDefinition(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition);

		void Ensure(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, ModuleDefinition module, TypeDefinition type);
	}
}
