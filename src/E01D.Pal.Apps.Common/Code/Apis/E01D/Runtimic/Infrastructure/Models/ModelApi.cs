using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Unified;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models
{
    public class ModelApi<TContainer> : SemanticApiNode<TContainer>, ModelApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public Semantic.SemanticApi_I<TContainer> Semantic { get; set; }

	    public StructuralApi_I<TContainer> Structural { get; set; }

	    public UnifiedApi_I<TContainer> Unified { get; set; }




		Semantic.SemanticApiMask_I ModelApiMask_I.Semantic => Semantic;

		

	


	    StructuralApiMask_I ModelApiMask_I.Structural => Structural;

	    UnifiedApiMask_I ModelApiMask_I.Unified => Unified;


	}
}
