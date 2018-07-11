using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.GenericInstances
{
    public interface GenericInstanceApi_I<TContainer> : GenericInstanceApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        
    }
}
