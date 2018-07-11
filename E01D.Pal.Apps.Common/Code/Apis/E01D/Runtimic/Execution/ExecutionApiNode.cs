using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution
{
    public class ExecutionApiNode<TContainer> : Api<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }

    public class ExecutionApiNode<TContainer, TUnderlying> : Api<TContainer, TUnderlying>
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
