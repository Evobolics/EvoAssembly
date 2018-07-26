using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Signatures
{
    public class SignatureApi<TContainer> : ConversionApiNode<TContainer>, SignatureApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public LocalVariableSignatureApi_I<TContainer> LocalVariableSignatures { get; set; }
        

        LocalVariableSignatureApiMask_I SignatureApiMask_I.LocalVariableSignatures => LocalVariableSignatures;

        public byte[] GetLocalSignature(ILConversion conversion, ConvertedRoutine convertedRoutine)
        {
            return LocalVariableSignatures.GetLocalSignature(conversion, convertedRoutine);
        }
    }
}
