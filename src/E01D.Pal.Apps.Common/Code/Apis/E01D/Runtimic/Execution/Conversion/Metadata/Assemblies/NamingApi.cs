using System;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public class NamingApi<TContainer> : ConversionApiNode<TContainer>, NamingApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    public string GetAssemblyName(ILConversion conversion, string assemblyName)
	    {
		    return GetAssemblyName(conversion, assemblyName, Guid.Empty);
	    }

		public string GetAssemblyName(ILConversion conversion, string assemblyName, Guid guid)
		{
		    bool isConverted = Assemblies.Query.IsConverted(conversion, assemblyName);

		    

		    if (assemblyName.Contains(","))
		    {
		        var parts = assemblyName.Split(',');

		        assemblyName = parts[0];
		    }

			if (!conversion.Configuration.AddAssemblyPrefixAndSuffix) return assemblyName;

			var prefix = string.Empty;

		    if (isConverted)
		    {
		        prefix = conversion.Configuration.BuilderAccess == AssemblyBuilderAccess.RunAndCollect ? "collectible_" : "converted_";
		    }

			if (guid == Guid.Empty)
			{
				return $"{prefix}{assemblyName}";
			}

			return  $"{prefix}{assemblyName}_{guid.ToString("N")}";

			
		}
	}
}
