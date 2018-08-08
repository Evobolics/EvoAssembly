using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural.Types;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural
{
	public interface StructuralApiMask_I
	{
		StructuralModulesApiMask_I Modules { get; }

		StructuralTypesApiMask_I Types { get; }

		void AddAssemblyDefinition(RuntimicSystemModel semanticModel, AssemblyDefinition assemblyDefinition);

		void Ensure(RuntimicSystemModel semanticModel, AssemblyDefinition assemblyDefinition, ModuleDefinition module, TypeDefinition type);
	}
}
