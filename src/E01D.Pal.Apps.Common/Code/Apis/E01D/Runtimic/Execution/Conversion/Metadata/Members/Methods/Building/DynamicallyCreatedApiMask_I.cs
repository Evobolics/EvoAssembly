using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building
{
	public interface DynamicallyCreatedApiMask_I
	{
		void BuildMethods(ILConversion conversion, ConvertedTypeDefinitionMask_I input);

		void BuildMethod(ILConversion conversion, ConvertedTypeWithMethods_I input, MethodDefinition method);

		void AddAllMethodOverrides(ILConversion conversion, ConvertedTypeDefinition_I converted);
	}
}
