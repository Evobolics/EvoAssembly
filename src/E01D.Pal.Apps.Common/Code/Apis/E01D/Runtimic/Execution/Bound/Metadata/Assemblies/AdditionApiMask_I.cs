using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
	public interface AdditionApiMask_I
	{
	    void AddAssemblyEntry(InfrastructureRuntimicModelMask_I semanticModel, SemanticAssemblyMask_I entry);

	}
}
