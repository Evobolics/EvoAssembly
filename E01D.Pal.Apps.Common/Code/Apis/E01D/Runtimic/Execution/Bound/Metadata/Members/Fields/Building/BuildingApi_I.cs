using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Fields.Building
{
    public interface BuildingApi_I<TContainer> : BuildingApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    new GenericApi_I<TContainer> Generic { get; }

	    new NonGenericApi_I<TContainer> NonGeneric { get; }
	}
}
