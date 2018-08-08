using Root.Code.Enums.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic
{
    public class InfrastructureRuntimicModel:InfrastructureRuntimicModel_I
    {


		

		public SemanticModel Semantic { get; set; } = new SemanticModel();

		public StructuralModel Structural { get; set; } = new StructuralModel();

	    public UnifiedModel Unified { get; set; } //= new UnifiedModel();

		
	    public object ObjectNetwork { get; set; }

		public RuntimicKind RuntimicKind => RuntimicKind.Semantic;

	    SemanticModelMask_I InfrastructureRuntimicModelMask_I.Semantic => Semantic;

	    StructuralModelMask_I StructuralRuntimicModelMask_I.Structural => Structural;

	    UnifiedModelMask_I UnifiedRuntimicModelMask_I.Unified => Unified;



	}
}
