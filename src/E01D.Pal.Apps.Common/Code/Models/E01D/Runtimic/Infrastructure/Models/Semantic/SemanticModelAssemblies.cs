using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Semantic
{
	public class SemanticModelAssemblies: SemanticModelAssembliesMask_I
	{
		public List<SemanticAssemblyMask_I> InDependencyOrder { get; set; }

		public Dictionary<string, SemanticAssemblyMask_I> ByResolutionName { get; set; } = new Dictionary<string, SemanticAssemblyMask_I>();
	}
}
