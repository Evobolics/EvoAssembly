using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural.Types
{
    public interface StructuralTypesApi_I<TContainer> : StructuralTypesApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    new ExternalApi_I<TContainer> External { get; set; }

		new CollectionApi_I<TContainer> Collection { get; set; }

	    
	}
}
