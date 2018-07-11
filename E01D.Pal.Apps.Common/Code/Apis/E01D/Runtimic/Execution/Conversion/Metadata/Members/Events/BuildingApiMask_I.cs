using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Events
{
    public interface BuildingApiMask_I
    {
        void BuildEvents(ILConversion conversion, ConvertedTypeDefinition_I input);
    }
}
