using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models
{
    public interface ModelApiMask_I
    {
	    SemanticApiMask_I Semantic { get; }

		StructuralApiMask_I Structural { get; }

	    


	}
}
