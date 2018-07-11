using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Assemblies
{
	public interface CreationApiMask_I
	{
	    
        BoundAssemblyMask_I CreateAssemblyEntry(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, Assembly assembly);
    }
}
