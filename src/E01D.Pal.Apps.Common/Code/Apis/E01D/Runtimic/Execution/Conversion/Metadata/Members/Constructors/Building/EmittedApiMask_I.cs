using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Building
{
	public interface EmittedApiMask_I
	{
		void BuildConstructor(ILConversion conversion, ConvertedTypeDefinitionMask_I input, MethodDefinition methodDefinition);
	}
}
