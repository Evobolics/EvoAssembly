using System.Reflection;
using Mono.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public interface NamingApiMask_I
	{
		string GetAssemblyName(Assembly assembly);

		string GetAssemblyName(AssemblyDefinition assemblyDefinition);

		string GetAssemblyName(IMetadataScope scope);

		string GetAssemblyName(TypeReference typeReference);
	}
}
