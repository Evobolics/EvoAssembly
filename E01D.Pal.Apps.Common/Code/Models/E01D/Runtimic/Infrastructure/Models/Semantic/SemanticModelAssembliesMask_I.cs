using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Semantic
{
	public interface SemanticModelAssembliesMask_I
	{
		Dictionary<string, SemanticAssemblyMask_I> ByResolutionName { get; }

		

		
		List<SemanticAssemblyMask_I> InDependencyOrder { get; }
	}
}
