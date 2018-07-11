using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Baking
{
    public interface BakingApi_I<TContainer> : BakingApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
