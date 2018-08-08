using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Modules
{
    public class ModuleApi<TContainer> : SemanticApiNode<TContainer>, ModuleApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    

        
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I ModuleApiMask_I.Building => Building;

        
        public EnsuringApi_I<TContainer> Ensuring { get; set; }

        EnsuringApiMask_I ModuleApiMask_I.Ensuring => Ensuring;

	    public void Get(RuntimicSystemModel model, object semanticAssembly, TypeReference typeReference)
	    {
		    throw new System.Exception("Get not implemented for semantic search yet.");
	    }


	}
}
