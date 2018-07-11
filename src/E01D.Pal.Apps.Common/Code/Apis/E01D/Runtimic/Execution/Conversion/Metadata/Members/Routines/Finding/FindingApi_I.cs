using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines.Finding
{
    public interface FindingApi_I<TContainer> : FindingApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new ParameterMatchingApi_I<TContainer> ParameterMatching { get; set; }

        new TypeMatchingApi_I<TContainer> TypeMatching { get; set; }
    }
}
