using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Building
{
    public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
    where TContainer : RuntimicContainer_I<TContainer>
    {
		public EmittedApi_I<TContainer> Emitted { get; set; }

	    EmittedApiMask_I BuildingApiMask_I.Emitted => Emitted;

	    public RuntimeCreatedApi_I<TContainer> RuntimeCreated { get; set; }

	    RuntimeCreatedApiMask_I BuildingApiMask_I.RuntimeCreated => RuntimeCreated;

		
    }
}
