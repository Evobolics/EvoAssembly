using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public interface ModuleApiMask_I
	{
		UnifiedModuleNode Extend(UnifiedRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode, ModuleDefinition moduleDefinition);
		UnifiedModuleNode Get(InfrastructureRuntimicModelMask_I model, string moduleName);
	}
}
