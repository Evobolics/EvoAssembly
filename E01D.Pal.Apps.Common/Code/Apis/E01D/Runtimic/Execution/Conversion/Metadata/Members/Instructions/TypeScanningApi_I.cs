using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions
{
    public interface TypeScanningApi_I<TContainer> : TypeScanningApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
