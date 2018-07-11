using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models
{
    public interface ModelApiMask_I
    {
	    SemanticApiMask_I Semantic { get; }

		StructuralApiMask_I Structural { get; }

	    UnifiedApiMask_I Unified { get; }


	}
}
