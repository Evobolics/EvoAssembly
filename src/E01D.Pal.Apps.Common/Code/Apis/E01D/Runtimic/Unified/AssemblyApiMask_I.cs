using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
    public interface AssemblyApiMask_I
    {
	    UnifiedAssemblyNode Extend(RuntimicSystemModel model, AssemblyDefinition assemblyDefinition);

	    UnifiedAssemblyNode Get(RuntimicSystemModel model, string resolutionName);

	    void AddCrossReference(RuntimicSystemModel model, UnifiedAssemblyNode node, string crossReferenceKey);


    }
}
