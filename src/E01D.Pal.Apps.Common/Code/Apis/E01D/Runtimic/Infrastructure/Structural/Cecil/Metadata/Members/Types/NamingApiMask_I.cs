using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface NamingApiMask_I
	{

		string GetAssemblyQualifiedName(TypeReference input, string targetAssemblyName);
		string AdjustResolutionName(string resolutionName);

		string GetAssemblyQualifiedName(TypeReference input);
		


        string GetResolutionName(TypeReference input);

		string GetResolutionName(System.Type input);

		
		
		string GetCliFullName(TypeReference typeReference);
	}
}
