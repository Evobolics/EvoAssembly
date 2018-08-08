using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
    public interface EnsuringApiMask_I
    {
        SemanticAssemblyMask_I Ensure(RuntimicSystemModel semanticModel, TypeReference typeReference);

        SemanticAssemblyMask_I Ensure(RuntimicSystemModel semanticModel, AssemblyDefinition assemblyDefinition);

        

        
    }
}
