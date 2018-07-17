using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
	public class AdditionApi<TContainer> : BoundApiNode<TContainer>, AdditionApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public void AddAssemblyEntry(InfrastructureRuntimicModelMask_I semanticModel, SemanticAssemblyMask_I entry)
        {
	        throw new System.Exception("Not supported currently.");
	        //semanticModel.Semantic.Assemblies.ByResolutionName.Add(entry.ResolutionName(), entry);

	        //Infrastructure.Models.Structural.AddAssemblyDefinition(semanticModel, entry.AssemblyDefinition);
        }

        
    }
}
