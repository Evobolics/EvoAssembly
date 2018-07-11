using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.GarbageCollection
{
    public class GarbageCollectionApi<TContainer>:ExecutionApiNode<TContainer>, GarbageCollectionApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

    }
}
