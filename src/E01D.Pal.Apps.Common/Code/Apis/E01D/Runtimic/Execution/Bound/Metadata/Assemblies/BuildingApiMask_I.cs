using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Modeling.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
    public interface BuildingApiMask_I
    {
        SemanticAssemblyMask_I BuildOut(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition);

        void BuildOut(InfrastructureRuntimicModelMask_I semanticModel, SemanticAssemblyMask_I boundAssembly);
	    void Build(InfrastructureRuntimicModelMask_I conversionModel, List<UnifiedAssemblyNode> referencedList);
    }
}
