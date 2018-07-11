using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Exts.Runtimic
{
	public static class RuntimicContainerExts
	{
		public static ILConversionResult ConvertType(this RuntimicContainer container, System.Type type)
		{
			return container.Api.Runtimic.Execution.Emitting.Conversion.ConvertType(type);
		}
	}
}
