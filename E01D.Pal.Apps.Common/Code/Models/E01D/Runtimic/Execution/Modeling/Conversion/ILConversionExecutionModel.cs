using Root.Code.Enums.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Structural;

namespace Root.Code.Models.E01D.Runtimic.Execution.Modeling.Conversion
{
    public class ILConversionExecutionModel:  InfrastructureModel_I
	{
        public ILConversionExecutionModel()
        {
                
        }

	    

		public ILConversion Conversion { get; set; }
		public ILConversionModel Semantic { get; set; } = new ILConversionModel();

		public StructuralModel Structural { get; set; } = new StructuralModel();

		SemanticModelMask_I InfrastructureModelMask_I.Semantic => Semantic;

		StructuralModelMask_I InfrastructureModelMask_I.Structural => Structural;



		public RuntimicKind RuntimicKind => RuntimicKind.Semantic;
		public object ObjectNetwork { get; set; }
	}
}
