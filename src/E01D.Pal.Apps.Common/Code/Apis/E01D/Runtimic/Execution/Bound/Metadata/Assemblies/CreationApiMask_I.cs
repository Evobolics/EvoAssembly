using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
	public interface CreationApiMask_I
	{
	    
        BoundAssemblyMask_I CreateAssemblyEntry(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, Assembly assembly);
    }
}
