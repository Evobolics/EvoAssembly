using System;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling.Types
{
    public interface ModelTypesApiMask_I
    {
        

        SemanticTypeDefinitionMask_I Get(InfrastructureRuntimicModelMask_I conversion, string typeDefinitionFullName);

        

        System.Type GetBoundUnderlyingTypeOrThrow(SemanticTypeMask_I semanticType);
        BoundTypeDefinitionMask_I GetBoundTypeOrThrow(SemanticTypeMask_I semanticType, bool allowNulls);

        SemanticTypeMask_I GetOrThrow(InfrastructureRuntimicModelMask_I conversion, string typeDefinitionFullName);

        

        TypeReference GetTypeReference(ILConversion conversion, Type input);

	    TypeReference GetTypeReference(ILConversion conversion, Type input,
		    out SemanticTypeDefinitionMask_I possibleSemanticType);


		

		



		TypeDefinition ResolveToTypeDefinition(InfrastructureRuntimicModelMask_I model, TypeReference typeReference);

        bool TryGet(InfrastructureRuntimicModelMask_I model, TypeReference input, out SemanticTypeDefinitionMask_I typeEntry);

        

        bool TryGet(InfrastructureRuntimicModelMask_I model, string resolutionName, out SemanticTypeDefinitionMask_I typeEntry);


        
    }
}
