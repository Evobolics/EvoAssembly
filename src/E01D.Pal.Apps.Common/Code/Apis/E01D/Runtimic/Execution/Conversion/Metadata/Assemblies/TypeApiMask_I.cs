using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public interface TypeApiMask_I
	{
		ILConversionResult Convert(ILConversion conversion, TypeDefinition[] inputTypes);
	}
}
