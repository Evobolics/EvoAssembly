using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator.IL
{
    public interface ILApiMask_I
    {
        GenerationApiMask_I Generation { get; }

        bool EmitILStream(ILConversion conversion, ConvertedRoutine convertedConstructor);
    }
}
