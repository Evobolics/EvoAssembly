using Root.Code.Apis.E01D.Runtimic.Infrastructure.Basic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure
{
    public interface InfrastructureApiMask_I
    {
	    BasicApiMask_I Basic { get; }

		ModelApiMask_I Models { get; }

		SemanticApiMask_I Semantic { get; }

	    StructuralApiMask_I Structural { get; }
	}
}
