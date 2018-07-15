using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public interface ExtendingApiMask_I
	{
		UnifiedAssemblyNode Extend(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, List<UnifiedTypeNode> types);
	}
}
