using Root.Code.Enums.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Signatures
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>For more information on how to parse Local Variable Signatures see "II.23.2.6 - LocalVarSig".</remarks>
    public class ConvertedLocalVariableSignature: ConvertedParameterSignature 
    {
        public SignaturePrefixKind Prefix { get; } = SignaturePrefixKind.LocalsSignature;
    }
}
