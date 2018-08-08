using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
    public interface BuildingApiMask_I
    {
        SemanticAssemblyMask_I BuildOut(RuntimicSystemModel semanticModel, AssemblyDefinition assemblyDefinition);

        void BuildOut(RuntimicSystemModel semanticModel, SemanticAssemblyMask_I boundAssembly);
	    //void Build(BoundRuntimicModelMask_I conversionModel, List<UnifiedAssemblyNode> referencedList);
    }
}
