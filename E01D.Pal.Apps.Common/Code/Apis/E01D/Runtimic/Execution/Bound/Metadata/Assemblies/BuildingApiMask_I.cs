using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Assemblies
{
    public interface BuildingApiMask_I
    {
        SemanticAssemblyMask_I BuildOut(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition);

        void BuildOut(InfrastructureModelMask_I semanticModel, SemanticAssemblyMask_I boundAssembly);
    }
}
