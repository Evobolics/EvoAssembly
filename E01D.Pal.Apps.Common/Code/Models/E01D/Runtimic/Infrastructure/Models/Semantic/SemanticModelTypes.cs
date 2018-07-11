using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Semantic
{
	public class SemanticModelTypes: SemanticModelTypesMask_I
    {
		public Dictionary<string, SemanticTypeDefinitionEntry> ByResolutionName { get; set; } = new Dictionary<string, SemanticTypeDefinitionEntry>();
    }
}
