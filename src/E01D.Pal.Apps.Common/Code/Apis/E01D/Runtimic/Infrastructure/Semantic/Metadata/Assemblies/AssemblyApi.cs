using System;
using Mono.Cecil;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Assemblies
{
    public class AssemblyApi<TContainer> : SemanticApiNode<TContainer>, AssemblyApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    

        
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I AssemblyApiMask_I.Building => Building;

        
        public EnsuringApi_I<TContainer> Ensuring { get; set; }

        EnsuringApiMask_I AssemblyApiMask_I.Ensuring => Ensuring;

	    public SemanticAssemblyMask_I Get(InfrastructureRuntimicModelMask_I model, TypeReference typeReference)
	    {
		    var assemblyName = Infrastructure.Structural.Cecil.Metadata.Assemblies.Naming.GetAssemblyName(typeReference);

		    if (TryGet(model, assemblyName, out SemanticAssemblyMask_I assemblyEntry))
		    {
			    return assemblyEntry;
		    }

		    return null;
	    }

	    public SemanticAssemblyMask_I Get(InfrastructureRuntimicModelMask_I model, string typeResolutionName)
	    {
		    var semanticType = Infrastructure.Models.Semantic.Types.Collection.Get(model, typeResolutionName);

		    if (semanticType == null)
		    {
			    throw new Exception($"Assembly ensure does not support scope '{typeResolutionName}'");
		    }

		    return semanticType.Module.Assembly;
	    }

	    public bool TryGet(InfrastructureRuntimicModelMask_I model, string resolutionName, out SemanticAssemblyMask_I semanticAssemblyMask)
	    {
		    var node = Unified.Assemblies.Get(model, resolutionName);

		    semanticAssemblyMask = node?.Semantic;

		    return node != null;
	    }
	}
}
