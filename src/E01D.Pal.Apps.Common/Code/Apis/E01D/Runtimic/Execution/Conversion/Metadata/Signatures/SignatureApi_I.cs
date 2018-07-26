using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Signatures
{
    public interface SignatureApi_I<TContainer> : SignatureApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        
    }
}
