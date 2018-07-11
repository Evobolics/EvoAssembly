using Root.Code.Apis.E01D.Runtimic.Execution.Allocation;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting;
using Root.Code.Apis.E01D.Runtimic.Execution.GarbageCollection;
using Root.Code.Apis.E01D.Runtimic.Execution.JustInTime;
using Root.Code.Apis.E01D.Runtimic.Execution.VirtualMachines;

namespace Root.Code.Apis.E01D.Runtimic.Execution
{
    public interface ExecutionApiMask_I
    {
        AllocationApiMask_I Allocation { get;  }

        BindingApiMask_I Binding { get;  }

        EmittingApiMask_I Emitting { get;  }

        GarbageCollectionApiMask_I GarbageCollection { get;  }

        // ReSharper disable once InconsistentNaming


        JustInTimeApiMask_I JustInTime { get;  }



        VirtualMachineApiMask_I VirtualMachines { get;  }

       
    }
}
