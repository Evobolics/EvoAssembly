using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
    public interface AssemblyApiMask_I
    {
	    UnifiedAssemblyNode Extend(UnifiedRuntimicModelMask_I model, AssemblyDefinition assemblyDefinition);

	    UnifiedAssemblyNode Get(UnifiedRuntimicModelMask_I model, string resolutionName);

	    void AddCrossReference(UnifiedRuntimicModelMask_I model, UnifiedAssemblyNode node, string crossReferenceKey);


    }
}
