using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Methods.Building
{
    public class BuildingApi<TContainer> : BindingApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {



		public DynamicallyCreatedApi_I<TContainer> DynamicallyCreated { get; set; }

	    DynamicallyCreatedApiMask_I BuildingApiMask_I.Emitted => DynamicallyCreated;

	    public RuntimeCreatedApi_I<TContainer> RuntimeCreated { get; set; }

	    RuntimeCreatedApiMask_I BuildingApiMask_I.RuntimeCreated => RuntimeCreated;

















	}
}
