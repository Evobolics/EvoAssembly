﻿using Root.Code.Apis.E01D.Runtimic.Execution.Allocation;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting;
using Root.Code.Apis.E01D.Runtimic.Execution.GarbageCollection;
using Root.Code.Apis.E01D.Runtimic.Execution.JustInTime;
using Root.Code.Apis.E01D.Runtimic.Execution.VirtualMachines;
using Root.Code.Apis.E01D.Runtimic.Execution.Metadata;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution
{
    public interface ExecutionApi_I<TContainer>: ExecutionApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {
        new AllocationApi_I<TContainer> Allocation { get; }

        new BindingApi_I<TContainer> Bound { get; }

	    new ConversionApi_I<TContainer> Conversion { get; set; }

		new EmittingApi_I<TContainer> Emitting { get; }

        new GarbageCollectionApi_I<TContainer> GarbageCollection { get; }

        new MetadataApi_I<TContainer> Metadata { get; }


        


        new JustInTimeApi_I<TContainer> JustInTime { get; }



        new VirtualMachineApi_I<TContainer> VirtualMachines { get; }
    }
}
