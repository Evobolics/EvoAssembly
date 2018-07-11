using Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Structural;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models
{
    public interface InfrastructureModelMask_I: RuntimicNode_I
    {
       

       

	    SemanticModelMask_I Semantic { get; }

		StructuralModelMask_I Structural { get;  }
	    
    }
}
