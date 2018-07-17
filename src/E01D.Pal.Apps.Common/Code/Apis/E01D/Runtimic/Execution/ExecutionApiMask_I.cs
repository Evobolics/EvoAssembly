using Root.Code.Apis.E01D.Runtimic.Execution.Allocation;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting;
using Root.Code.Apis.E01D.Runtimic.Execution.GarbageCollection;
using Root.Code.Apis.E01D.Runtimic.Execution.JustInTime;
using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types;
using Root.Code.Apis.E01D.Runtimic.Execution.VirtualMachines;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Execution
{
    public interface ExecutionApiMask_I
    {
        AllocationApiMask_I Allocation { get;  }

        BindingApiMask_I Binding { get;  }

	    ConversionApiMask_I Conversion { get; }

		EmittingApiMask_I Emitting { get;  }

        GarbageCollectionApiMask_I GarbageCollection { get;  }

        


        JustInTimeApiMask_I JustInTime { get;  }



        VirtualMachineApiMask_I VirtualMachines { get;  }

	    Metadata.MetadataApiMask_I Metadata { get; }

	    CecilApiMask_I Cecil { get; }

	    TypeApiMask_I Types { get; }
	}
}
