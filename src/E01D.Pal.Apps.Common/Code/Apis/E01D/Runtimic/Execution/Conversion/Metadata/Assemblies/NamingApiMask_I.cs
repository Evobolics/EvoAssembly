using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public interface NamingApiMask_I
	{
		string GetAssemblyName(ILConversion conversion, string assemblyName);
	}
}
