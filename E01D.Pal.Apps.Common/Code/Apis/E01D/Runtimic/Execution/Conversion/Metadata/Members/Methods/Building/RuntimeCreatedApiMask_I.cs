using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building
{
	public interface RuntimeCreatedApiMask_I
	{
		void BuildMethods(ILConversion conversion, ConvertedGenericTypeDefinition_I input);
	}
}
