using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;

namespace Root.Code.Models.E01D.Runtimic.Execution.Modeling.Conversion
{
	public class ILConversionSemanticModelTypes: SemanticModelTypesMask_I
	{
		public Dictionary<string, SemanticTypeDefinitionEntry> ByResolutionName { get; set; } =
			new Dictionary<string, SemanticTypeDefinitionEntry>();

		public Dictionary<string, ConvertedTypeDefinition_I> ConvertedTypes { get; set; } =
	        new Dictionary<string, ConvertedTypeDefinition_I>();
	}
}
