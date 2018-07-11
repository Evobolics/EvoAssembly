using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure
{
    public interface InfrastructureApi_I<TContainer>: InfrastructureApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    new ModelApi_I<TContainer> Models { get; set; }

	    new SemanticApi_I<TContainer> Semantic { get; set; }

		new StructuralApi_I<TContainer> Structural { get; set; }
	}
}
