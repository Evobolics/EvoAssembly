using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public interface GettingApiMask_I
    {
		SemanticAssemblyMask_I GetAssembly(ILConversion conversion, AssemblyDefinition assemblyDefinition);

	    SemanticAssemblyMask_I GetAssembly(ILConversion conversion, Assembly assembly);

	    SemanticAssemblyMask_I GetAssembly(RuntimicSystemModel model, string fullName);

	    

	    SemanticAssemblyMask_I GetAssembly(RuntimicSystemModel conversion, AssemblyDefinition assemblyDefinition);

	    

		
	}
}
