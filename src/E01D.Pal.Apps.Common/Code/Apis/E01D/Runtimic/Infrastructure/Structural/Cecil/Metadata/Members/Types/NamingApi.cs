using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;

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

		

		public string GetCliFullName(TypeReference typeReference)
		{
			if (typeReference.IsByReference)
			{
				ByReferenceType byReferenceType = (ByReferenceType)typeReference;

				return GetCliFullName(byReferenceType.ElementType) + "&";
			}

			if (typeReference.IsPointer)
			{
				PointerType pointerType = (PointerType)typeReference;

				return GetCliFullName(pointerType.ElementType) + "*";
			}

			if (typeReference.IsArray)
			{
				ArrayType arrayType = (ArrayType) typeReference;
				string fullNameArray = typeReference.FullName;
				var suffixStartIndex = fullNameArray.IndexOf("[", StringComparison.Ordinal);

				string suffix = typeReference.FullName.Substring(suffixStartIndex, fullNameArray.Length - suffixStartIndex);

				fullNameArray = GetCliFullName(arrayType.ElementType) + suffix;

				return fullNameArray;
			}

			if (typeReference.IsGenericParameter)
			{
				GenericParameter gp = (GenericParameter) typeReference;

				if (gp.Type == GenericParameterType.Type)
				{
					return GetCliFullName(gp.DeclaringType) + "!!" + gp.Position;
				}
				else
				{
					string methodFullName = Methods.GetResolutionName(gp.DeclaringMethod);

					return methodFullName + "!!" + gp.Position;
				}

				
			}

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
