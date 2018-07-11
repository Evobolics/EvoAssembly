using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Building
{
	public interface RuntimeCreatedApiMask_I
	{
		void BuildConstructors(ILConversion conversion, ConvertedGenericTypeDefinitionMask_I input);

		void BuildConstructors(ILConversion conversion, ConvertedArrayTypeDefinitionMask_I input);
	}
}
