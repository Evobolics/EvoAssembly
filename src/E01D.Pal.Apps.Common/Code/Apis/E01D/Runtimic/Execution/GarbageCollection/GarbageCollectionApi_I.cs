using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.GarbageCollection
{
    public interface GarbageCollectionApi_I<TContainer>: GarbageCollectionApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {

    }
}
