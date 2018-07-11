using System;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural.Types
{
    public interface StructuralTypesApiMask_I
    {
	    CollectionApiMask_I Collection { get; }

	    ExternalApiMask_I External { get; }



		

       

        

        ModuleDefinition GetModuleFromType(InfrastructureModelMask_I semanticModel, string resolutionName);

        

        //TypeReference GetTypeReference(InfrastructureModelMask_I model, Type input);
     

        Type ResolveToType(InfrastructureModelMask_I model, SemanticTypeDefinitionMask_I semanticType);
    }
}
