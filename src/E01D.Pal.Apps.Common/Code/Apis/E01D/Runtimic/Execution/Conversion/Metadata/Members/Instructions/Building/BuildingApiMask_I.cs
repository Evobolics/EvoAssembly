using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.IL;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building
{
    public interface BuildingApiMask_I
    {
        ILApiMask_I IL { get; }

        void BuildInstructions(ILConversion conversion, ConvertedTypeDefinition_I input);
    }
}
