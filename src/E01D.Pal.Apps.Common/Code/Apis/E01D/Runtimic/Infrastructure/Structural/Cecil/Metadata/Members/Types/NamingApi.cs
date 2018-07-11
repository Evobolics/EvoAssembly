using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public class NamingApi<TContainer> : RuntimeApiNode<TContainer>, NamingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public string GetAssemblyQualifiedName(TypeReference input)
		{
			// TODO: Fix
			string assemblyName = Infrastructure.Structural.Cecil.Metadata.Assemblies.GetAssemblyName(input);

			var fullName = input.FullName?.Replace("/", "+") ?? string.Empty;

			return fullName + ", " + assemblyName;
		}

		public string GetResolutionName(TypeReference input)
		{
			var fullName = GetAssemblyQualifiedName(input);

			return AdjustResolutionName(fullName);
		}

		public string GetResolutionName(System.Type input)
		{
			var fullName = input.AssemblyQualifiedName;

			if (fullName == null)
			{
				fullName = $"{input.Namespace}.{input.Name}, {input.Assembly.FullName}";
			}

			return AdjustResolutionName(fullName);

		}

		public string AdjustResolutionName(string resolutionName)
		{
			resolutionName = resolutionName.Replace("/", "+");

			if (!string.IsNullOrEmpty(resolutionName) && resolutionName.Contains("&"))
			{
				return resolutionName.Replace("&", "");
			}

			return resolutionName;
		}
	}
}
