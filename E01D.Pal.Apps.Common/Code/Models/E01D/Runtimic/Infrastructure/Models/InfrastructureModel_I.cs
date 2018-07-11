using Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Structural;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models
{
    public interface InfrastructureModel_I: InfrastructureModelMask_I
    {
	    new StructuralModel Structural { get; set; }
	}
}
