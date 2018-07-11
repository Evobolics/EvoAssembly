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
		    bool isConverted = Assemblies.IsConverted(conversion, assemblyName);

		    

		    if (assemblyName.Contains(","))
		    {
		        var parts = assemblyName.Split(new char[] {','});

		        assemblyName = parts[0];
		    }

            string prefix = string.Empty;

		    if (isConverted)
		    {
		        prefix = conversion.Configuration.BuilderAccess == AssemblyBuilderAccess.RunAndCollect ? "collectible_" : "converted_";
		    }

		    var name = prefix + assemblyName;

			return name;
		}
	}
}
