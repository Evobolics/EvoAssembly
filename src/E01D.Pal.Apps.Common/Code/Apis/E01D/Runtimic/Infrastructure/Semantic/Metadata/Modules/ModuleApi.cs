﻿using Mono.Cecil;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Modules
{
    public class ModuleApi<TContainer> : SemanticApiNode<TContainer>, ModuleApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    

        [ValueSetDynamically]
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I ModuleApiMask_I.Building => Building;

        [ValueSetDynamically]
        public EnsuringApi_I<TContainer> Ensuring { get; set; }

        EnsuringApiMask_I ModuleApiMask_I.Ensuring => Ensuring;

	    public void Get(InfrastructureModelMask_I model, object semanticAssembly, TypeReference typeReference)
	    {
		    throw new System.Exception("Get not implemented for semantic search yet.");
	    }


	}
}