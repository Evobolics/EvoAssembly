using Root.Code.Apis.E01D.Runtimic.Infrastructure.Basic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure
{
    public class InfrastructureApi<TContainer> : RuntimeApiNode<TContainer>, InfrastructureApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public BasicApi_I<TContainer> Basic { get; set; }

	    BasicApiMask_I InfrastructureApiMask_I.Basic => Basic;

		public SemanticApi_I<TContainer> Semantic { get; set; }

        SemanticApiMask_I InfrastructureApiMask_I.Semantic => Semantic;

	    public StructuralApi_I<TContainer> Structural { get; set; }

	    StructuralApiMask_I InfrastructureApiMask_I.Structural => Structural;

		public ModelApi_I<TContainer> Models { get; set; }

	    ModelApiMask_I InfrastructureApiMask_I.Models => this.Models;
	}
}
