using System;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types
{
    public interface ModelTypesApiMask_I
    {
	    CollectionApiMask_I Collection { get; }

	    



		

        void Ensure(InfrastructureRuntimicModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType);

        

        ModuleDefinition GetModuleFromType(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName);

        

        TypeReference GetTypeReference(InfrastructureRuntimicModelMask_I model, Type input);

	    TypeReference GetTypeReference(InfrastructureRuntimicModelMask_I model, Type input, out SemanticTypeDefinitionMask_I semanticType);



		Type ResolveToType(InfrastructureRuntimicModelMask_I model, SemanticTypeDefinitionMask_I semanticType);
    }
}
