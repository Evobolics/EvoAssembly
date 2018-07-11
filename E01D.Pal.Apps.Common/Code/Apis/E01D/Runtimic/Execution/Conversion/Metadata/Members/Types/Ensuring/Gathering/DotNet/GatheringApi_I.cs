using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering.DotNet
{
    public interface GatheringApi_I<TContainer> : GatheringApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
