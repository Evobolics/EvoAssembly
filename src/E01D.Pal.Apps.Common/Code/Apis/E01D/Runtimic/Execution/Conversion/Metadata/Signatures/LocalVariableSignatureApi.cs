using System;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Signatures;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Signatures
{
    public class LocalVariableSignatureApi<TContainer> : ConversionApiNode<TContainer>, LocalVariableSignatureApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

        public ConvertedLocalVariableSignature CreateLocalVariableSignature(ILConversion conversion)
        {
            return new ConvertedLocalVariableSignature()
            {
                Conversion = conversion
            };
        }

        public byte[] GetLocalSignature(ILConversion conversion, ConvertedRoutine routine)
        {
            ConvertedLocalVariableSignature signature = CreateLocalVariableSignature(conversion);

            throw new NotImplementedException();
        }
    }
}
