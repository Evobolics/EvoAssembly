using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.IL
{
    public interface ILApiMask_I
    {
        void GenerateIL(ILConversion conversion, ConvertedTypeDefinition_I input, ConvertedRoutine method);
    }
}
