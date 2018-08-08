using Root.Code.Models.E01D.Runtimic.Execution.Bound;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Models.E01D.Runtimic
{
	public class RuntimicTypeSystemModel
	{
		/// <summary>
		/// Gets or sets the runtimic system associated with the runtimic model.
		/// </summary>
		public BoundSystemModel Bound { get; set; }

		/// <summary>
		/// Gets or sets the conversional system associated with the runtimic model.
		/// </summary>
		public ConversionSystemModel Conversional { get; set; }

		/// <summary>
		/// Gets or sets the semantic system associated with the runtimic model.
		/// </summary>
		public SemanticSystemModel Semantic { get; set; }

		public StructuralSystemModel Structural { get; set; }

		/// <summary>
		/// Gets or sets the semantic system associated with the runtimic model.  The unified model provides a way to connect all the type system models together.
		/// </summary>
		public UnifiedSystemModel Unified { get; set; }

		
	}
}
