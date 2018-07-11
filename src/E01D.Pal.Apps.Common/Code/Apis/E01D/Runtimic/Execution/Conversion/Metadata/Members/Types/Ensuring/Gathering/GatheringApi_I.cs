using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering
{
    public interface GatheringApi_I<TContainer> : GatheringApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new CecilApi_I<TContainer> Cecil { get; set; }
    }
}
