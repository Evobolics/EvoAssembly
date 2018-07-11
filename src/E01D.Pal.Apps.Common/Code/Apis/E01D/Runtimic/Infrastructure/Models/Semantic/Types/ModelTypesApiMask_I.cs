using System;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types
{
    public interface ModelTypesApiMask_I
    {
	    CollectionApiMask_I Collection { get; }

	    



		

        void Ensure(InfrastructureModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType);

        

        ModuleDefinition GetModuleFromType(InfrastructureModelMask_I semanticModel, string resolutionName);

        

        TypeReference GetTypeReference(InfrastructureModelMask_I model, Type input);

	    TypeReference GetTypeReference(InfrastructureModelMask_I model, Type input, out SemanticTypeDefinitionMask_I semanticType);



		Type ResolveToType(InfrastructureModelMask_I model, SemanticTypeDefinitionMask_I semanticType);
    }
}
