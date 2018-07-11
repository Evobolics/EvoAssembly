using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Creation
{
    public interface DotNetApi_I<TContainer> : DotNetApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
