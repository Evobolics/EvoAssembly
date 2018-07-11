using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions
{
    public interface InstructionApiMask_I
    {
        BuildingApiMask_I Building { get; }

        TypeScanningApiMask_I TypeScanning { get; }
        System.Type GetGenericParameterType(ILConversion conversion, ConvertedTypeDefinition_I input, ConvertedRoutine method, GenericParameter genericParameter);
    }
}
