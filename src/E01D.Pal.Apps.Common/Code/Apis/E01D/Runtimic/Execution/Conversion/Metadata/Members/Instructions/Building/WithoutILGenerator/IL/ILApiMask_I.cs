using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator.IL
{
    public interface ILApiMask_I
    {
        GenerationApiMask_I Generation { get; }

        ConvertedILStream EmitILStream(ILConversion conversion, ConvertedEmittedConstructor convertedConstructor);
    }
}
