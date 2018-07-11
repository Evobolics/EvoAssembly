using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
    public interface ModelTypesApi_I<TContainer> : ModelTypesApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    new CollectionApi_I<TContainer> Collection { get; set; }

		new ExternalApi_I<TContainer> External { get; set; }
	}
}
