using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Signatures;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Signatures
{
    public interface LocalVariableSignatureApiMask_I
    {
        ConvertedLocalVariableSignature CreateLocalVariableSignature(ILConversion conversion);

        byte[] GetLocalSignature(ILConversion conversion, ConvertedRoutine routine);
    }
}
