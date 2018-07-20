using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
    public interface ModelTypesApiMask_I
    {
	    CollectionApiMask_I Collection { get; }

		ExternalApiMask_I External { get; }


        System.Type GetObjectType(BoundRuntimicModelMask_I model);

        System.Type GetValueType(BoundRuntimicModelMask_I model);

        System.Type GetEnumType(BoundRuntimicModelMask_I model);


        

	    System.Type GetUnderlyingType(BoundRuntimicModelMask_I model, TypeReference typeReference);

		TypeDefinition Resolve(BoundRuntimicModelMask_I model, Type genericTypeDefinitionType);

        System.Type GetBoundUnderlyingTypeOrThrow(BoundRuntimicModelMask_I model, string resolutionName);

        System.Type GetBoundUnderlyingTypeOrThrow(SemanticTypeMask_I semanticType);

        BoundTypeDefinitionMask_I GetBoundTypeOrThrow(SemanticTypeMask_I semanticType, bool allowNulls);


        TypeReference GetTypeReference(BoundRuntimicModelMask_I semanticModel, Type input);

	    TypeReference GetTypeReference(BoundRuntimicModelMask_I model, Type input, out SemanticTypeDefinitionMask_I possibleSemanticType);


		Type ResolveToType(BoundRuntimicModelMask_I model, TypeReference typeReference);

        System.Type ResolveToType(BoundRuntimicModelMask_I model, BoundTypeDefinitionMask_I semanticType);

        System.Type ResolveToType(BoundRuntimicModelMask_I model, SemanticTypeDefinitionMask_I semanticType, out BoundTypeDefinitionMask_I resultingBound);

	    System.Type ResolveToType(BoundRuntimicModelMask_I model, TypeReference typeReference, System.Type type, out BoundTypeDefinitionMask_I resultingBound);

		System.Type ResolveToType(BoundRuntimicModelMask_I model, TypeReference typeReference, out BoundTypeDefinitionMask_I boundType);



		BoundTypeDefinitionMask_I ResolveToBound(BoundRuntimicModelMask_I model, TypeReference declaringTypeRef);

	    

    }
}
