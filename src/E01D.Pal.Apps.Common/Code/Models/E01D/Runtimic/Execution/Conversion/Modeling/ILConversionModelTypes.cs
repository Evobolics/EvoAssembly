using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling
{
	public class ILConversionSemanticModelTypes: SemanticModelTypesMask_I
	{
		public Dictionary<string, UnifiedTypeNode> ByResolutionName { get; set; } =
			new Dictionary<string, UnifiedTypeNode>();

		public Dictionary<string, ConvertedTypeDefinition_I> ConvertedTypes { get; set; } =
	        new Dictionary<string, ConvertedTypeDefinition_I>();
	}
}
