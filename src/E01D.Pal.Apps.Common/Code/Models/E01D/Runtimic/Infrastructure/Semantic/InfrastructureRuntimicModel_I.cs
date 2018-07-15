using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic
{
    public interface InfrastructureRuntimicModel_I: InfrastructureRuntimicModelMask_I
    {
	    new SemanticModel Semantic { get; set; }

	    new StructuralModel Structural { get; set; }
	}
}
