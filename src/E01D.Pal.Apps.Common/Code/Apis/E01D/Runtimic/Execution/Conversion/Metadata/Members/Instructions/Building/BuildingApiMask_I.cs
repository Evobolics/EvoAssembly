using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithILGenerator;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building
{
    public interface BuildingApiMask_I
    {
        WithILGeneratorApiMask_I WithILGenerator { get; }

        WithoutILGeneratorApiMask_I WithoutILGenerator { get; }

        

        bool BuildInstructions(ILConversion conversion, ConvertedTypeDefinition_I input);
    }
}
