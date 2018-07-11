using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public interface EnumApi_I<TContainer> : EnumApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
