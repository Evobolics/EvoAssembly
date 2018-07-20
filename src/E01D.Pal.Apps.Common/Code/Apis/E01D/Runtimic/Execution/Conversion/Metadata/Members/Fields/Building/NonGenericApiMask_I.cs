using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields.Building
{
	public interface NonGenericApiMask_I
	{
		void BuildFields(ILConversion conversion, ConvertedTypeDefinition_I input);

		void BuildField(ILConversion conversion, ConvertedTypeDefinition_I input, FieldDefinition field);
	}
}
