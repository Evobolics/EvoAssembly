using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public interface ModuleApiMask_I
	{
		UnifiedModuleNode Extend(RuntimicSystemModel model, UnifiedAssemblyNode assemblyNode, ModuleDefinition moduleDefinition);
		UnifiedModuleNode Get(RuntimicSystemModel model, string moduleName);
		UnifiedModuleNode Ensure(RuntimicSystemModel boundModel, ModuleDefinition typeReferenceModule);
	}
}
