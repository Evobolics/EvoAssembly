using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.NonGenericInstances
{
	public interface Phase3InstructionBuildApiMask_I
	{
		void Build(ILConversion conversion, ConvertedTypeDefinition_I converted);
	}
}
