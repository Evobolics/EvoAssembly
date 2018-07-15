using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models
{
	/// <summary>
	/// The primary purpose of this class is to enable the search of assemblies in provided model.  Searching / gettting belongs in the model api
	/// as it is accessing the model.  Creating is type specific.  Thus it belongs in binding metadata assemblies 
	/// </summary>
	/// <typeparam name="TContainer"></typeparam>
    public class ModelAssembliesApi<TContainer> : BindingApiNode<TContainer>, ModelAssembliesApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public SemanticAssemblyMask_I Get(InfrastructureRuntimicModelMask_I model, TypeReference typeReference)
	    {
		    return Semantic.Metadata.Assemblies.Get(model, typeReference);
	    }

        public SemanticAssemblyMask_I Get(InfrastructureRuntimicModelMask_I model, string typeResolutionName)
        {
			return Semantic.Metadata.Assemblies.Get(model, typeResolutionName);
		}

        public bool TryGet(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName, out SemanticAssemblyMask_I semanticAssemblyMask)
        {
            return Semantic.Metadata.Assemblies.TryGet(semanticModel, resolutionName, out semanticAssemblyMask);
        }
    }
}
