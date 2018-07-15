using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic
{
    public interface InfrastructureRuntimicModelMask_I: StructuralRuntimicModelMask_I
	{
	    SemanticModelMask_I Semantic { get; }
	}
}
