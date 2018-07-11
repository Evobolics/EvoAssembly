using Mono.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Assemblies
{
	public interface NamingApiMask_I
	{
		//string GetAssemblyName(ILConversion conversion, string assemblyName, bool isConverted);
	    string GetResolutionName(AssemblyNameReference assemblyNameReference);
        string GetResolutionName(AssemblyDefinition assemblyDefinition);
    }
}
