using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public interface GenericApi_I<TContainer> : GenericInstancesApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        
    }
}
