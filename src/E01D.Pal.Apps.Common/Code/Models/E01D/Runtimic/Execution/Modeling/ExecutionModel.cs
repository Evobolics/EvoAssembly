using Root.Code.Enums.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Structural;

namespace Root.Code.Models.E01D.Runtimic.Execution.Modeling
{
	public class ExecutionModel: InfrastructureModelMask_I
	{
		public SemanticModel Semantic { get; set; } = new SemanticModel();

		public StructuralModel Structural { get; set; } = new StructuralModel();

		SemanticModelMask_I InfrastructureModelMask_I.Semantic => Semantic;

		StructuralModelMask_I InfrastructureModelMask_I.Structural => Structural;



		public RuntimicKind RuntimicKind => RuntimicKind.Semantic;
		public object ObjectNetwork { get; set; }
	}
}
