using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic
{
	public interface ModelAssembliesApiMask_I
	{
		SemanticAssemblyMask_I Get(InfrastructureModelMask_I model, TypeReference typeReference);

		SemanticAssemblyMask_I Get(InfrastructureModelMask_I model, string typeResolutionName);

		bool TryGet(InfrastructureModelMask_I model, string resolutionName, out SemanticAssemblyMask_I semanticAssemblyMask);
	}
}
