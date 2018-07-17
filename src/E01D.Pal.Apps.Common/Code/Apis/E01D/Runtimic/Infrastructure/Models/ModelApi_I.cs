using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models
{
    public interface ModelApi_I<TContainer> : ModelApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    new SemanticApi_I<TContainer> Semantic { get; set; }

		new StructuralApi_I<TContainer> Structural { get; set; }

	    


	}
}
