using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public interface GettingApiMask_I
	{
		List<AssemblyDefinition> GetAssemblies(InfrastructureRuntimicModelMask_I semanticModel, List<TypeReference> inputTypes);

		UnifiedAssemblyNode Get(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName);

		bool Get(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName, out UnifiedAssemblyNode node);
	}
}
