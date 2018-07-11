using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
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
	    public SemanticAssemblyMask_I Get(InfrastructureModelMask_I model, TypeReference typeReference)
	    {
		    return Infrastructure.Models.Semantic.Assemblies.Get(model, typeReference);
	    }

        public SemanticAssemblyMask_I Get(InfrastructureModelMask_I model, string typeResolutionName)
        {
			return Infrastructure.Models.Semantic.Assemblies.Get(model, typeResolutionName);
		}

        public bool TryGet(InfrastructureModelMask_I semanticModel, string resolutionName, out SemanticAssemblyMask_I semanticAssemblyMask)
        {
            return Infrastructure.Models.Semantic.Assemblies.TryGet(semanticModel, resolutionName, out semanticAssemblyMask);
        }
    }
}
