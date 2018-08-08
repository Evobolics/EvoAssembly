using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
    public interface ModelTypesApiMask_I
    {
	    CollectionApiMask_I Collection { get; }

		ExternalApiMask_I External { get; }


        System.Type GetObjectType(RuntimicSystemModel model);

        System.Type GetValueType(RuntimicSystemModel model);

        


        

	    System.Type GetUnderlyingType(RuntimicSystemModel model, TypeReference typeReference);

		

        System.Type GetBoundUnderlyingTypeOrThrow(RuntimicSystemModel model, string resolutionName);

        System.Type GetBoundUnderlyingTypeOrThrow(SemanticTypeMask_I semanticType);

        BoundTypeDefinitionMask_I GetBoundTypeOrThrow(SemanticTypeMask_I semanticType, bool allowNulls);


        TypeReference GetTypeReference(RuntimicSystemModel semanticModel, Type input);

	    TypeReference GetTypeReference(RuntimicSystemModel model, Type input, out SemanticTypeDefinitionMask_I possibleSemanticType);

	    TypeDefinition Resolve(RuntimicSystemModel model, Type genericTypeDefinitionType);






		



		//BoundTypeDefinitionMask_I ResolveToBound(BoundRuntimicModelMask_I model, TypeReference declaringTypeRef);

	    

    }
}
