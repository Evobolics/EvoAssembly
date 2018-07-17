using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public class NamingApi<TContainer> : CecilApiNode<TContainer>, NamingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public string GetAssemblyQualifiedName(TypeReference input)
		{
			// TODO: Fix
			string assemblyName = Infrastructure.Structural.Cecil.Metadata.Assemblies.Naming.GetAssemblyName(input);

			var fullName = GetCliFullName(input);

			return fullName + ", " + assemblyName;
		}

		public string GetAssemblyQualifiedName(TypeReference input, string targetAssemblyName)
		{
			var fullName = GetCliFullName(input);

			return fullName + ", " + targetAssemblyName;
		}

		public string GetPointerElementName(TypeReference input)
		{
			if (!input.IsPointer) throw new System.Exception("Expecting a pointer type.");

			var fullName = GetAssemblyQualifiedName(input);

			fullName = fullName.Replace("*", "");

			return fullName;
		}

		public string GetCliFullName(TypeReference typeReference)
		{
			var fullName = typeReference.FullName;

			return fullName?.Replace("/", "+") ?? string.Empty;
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
