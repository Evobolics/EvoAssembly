using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
    public interface GenericParameterApi_I<TContainer> : GenericParameterApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
