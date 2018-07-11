using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.JustInTime
{
    public class JustInTimeApi<TContainer> : ExecutionApiNode<TContainer>, JustInTimeApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

    }
}
