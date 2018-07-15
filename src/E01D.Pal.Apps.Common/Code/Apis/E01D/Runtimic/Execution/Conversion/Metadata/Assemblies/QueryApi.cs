using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public class QueryApi<TContainer> : ConversionApiNode<TContainer>, QueryApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public bool IsCorlib(IMetadataScope scope)
		{
			if (scope is AssemblyNameReference assemblyNameReference)
			{
				return IsCorlib(assemblyNameReference.FullName);
			}

			return IsCorlib(scope.Name);
		}

		public bool IsCorlib(string name)
		{
			return name.StartsWith("mscorlib");
		}

		public bool IsConverted(ILConversion conversion, IMetadataScope scope)
		{
			if (scope is AssemblyNameReference assemblyNameReference)
			{
				return IsConverted(conversion, assemblyNameReference.FullName);
			}

			return IsConverted(conversion, scope.Name);
		}

		public bool IsConverted(ILConversion conversion, string name)
		{
			if (conversion.Configuration.ConvertedAssemblies.ContainsKey(name))
			{
				return true;
			}

			if (IsCorlib(name) && conversion.Configuration.DoNotConvertCorlib)
			{
				return false;
			}

			return !conversion.Configuration.IsConvertingTypeSet;

		}
	}
}
