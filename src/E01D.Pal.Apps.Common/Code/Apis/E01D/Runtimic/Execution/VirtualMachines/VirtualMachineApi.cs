using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.VirtualMachines
{
    public class VirtualMachineApi<TContainer> : ExecutionApiNode<TContainer>, VirtualMachineApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
