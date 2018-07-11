using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Allocation
{
    public class AllocationApi<TContainer>:ExecutionApiNode<TContainer>, AllocationApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
