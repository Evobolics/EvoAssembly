using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Unified
{
	public interface UnifiedTypesApiMask_I
	{
		SemanticTypeDefinitionEntry GetSemanticEntry(InfrastructureModelMask_I semanticModel, string resolutionName);
	}
}
