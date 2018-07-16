using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Fields.Building
{
    public class BuildingApi<TContainer> : BoundApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public GenericApi_I<TContainer> Generic { get; set; }

	    GenericApiMask_I BuildingApiMask_I.Generic => Generic;

	    public NonGenericApi_I<TContainer> NonGeneric { get; set; }

	    NonGenericApiMask_I BuildingApiMask_I.NonGeneric => NonGeneric;


	}
}
