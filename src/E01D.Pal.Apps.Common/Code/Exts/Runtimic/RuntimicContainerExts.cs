using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Exts.Runtimic
{
	public static class RuntimicContainerExts
	{
		public static ILConversionResult Convert(this RuntimicContainer container, System.Type type)
		{
			return container.Api.Runtimic.Execution.Conversion.Convert(type);
		}

		public static ILConversionResult Convert(this RuntimicContainer container, System.Type type, AssemblyBuilderAccess access)
		{
			return container.Api.Runtimic.Execution.Conversion.Convert(type, access);
		}

		public static System.Reflection.Assembly Convert(this RuntimicContainer container, System.Reflection.Assembly assembly)
		{
			return container.Api.Runtimic.Execution.Conversion.QuickConvert(assembly);
		}
	}
}
