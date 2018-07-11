using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Assemblies
{
	public interface AdditionApiMask_I
	{
	    void AddAssemblyEntry(InfrastructureModelMask_I semanticModel, SemanticAssemblyMask_I entry);

	}
}
