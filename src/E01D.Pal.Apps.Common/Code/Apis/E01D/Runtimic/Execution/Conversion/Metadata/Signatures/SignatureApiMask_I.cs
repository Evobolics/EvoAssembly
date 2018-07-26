using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Signatures
{
    public interface SignatureApiMask_I
    {
        LocalVariableSignatureApiMask_I LocalVariableSignatures { get; }
        byte[] GetLocalSignature(ILConversion conversion, ConvertedRoutine convertedRoutine);
    }
}
