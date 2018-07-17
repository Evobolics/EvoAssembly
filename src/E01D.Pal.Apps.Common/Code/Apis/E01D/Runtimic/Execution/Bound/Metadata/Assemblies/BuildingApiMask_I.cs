using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
    public interface BuildingApiMask_I
    {
        SemanticAssemblyMask_I BuildOut(BoundRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition);

        void BuildOut(BoundRuntimicModelMask_I semanticModel, SemanticAssemblyMask_I boundAssembly);
	    void Build(BoundRuntimicModelMask_I conversionModel, List<UnifiedAssemblyNode> referencedList);
    }
}
