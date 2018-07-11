using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines.Finding
{
    public interface TypeMatchingApi_I<TContainer> : TypeMatchingApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
