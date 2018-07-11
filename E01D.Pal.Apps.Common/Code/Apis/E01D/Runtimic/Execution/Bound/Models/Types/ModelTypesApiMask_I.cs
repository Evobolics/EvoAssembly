using System;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Models.Types
{
    public interface ModelTypesApiMask_I
    {
	    CollectionApiMask_I Collection { get; }

		ExternalApiMask_I External { get; }

		

        //void Add(SemanticModelMask_I semanticModel, AssemblyDefinition assemblyDefinition,
        //    ModuleDefinition module, TypeDefinition type);

       

       // void Ensure(SemanticModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, ModuleDefinition module, TypeDefinition type);

        System.Type GetObjectType(InfrastructureModel_I model);

        System.Type GetValueType(InfrastructureModel_I model);

        System.Type GetEnumType(InfrastructureModel_I model);


        

	    System.Type GetUnderlyingType(InfrastructureModelMask_I model, TypeReference typeReference);

		TypeDefinition Resolve(InfrastructureModel_I model, Type genericTypeDefinitionType);

        System.Type GetBoundUnderlyingTypeOrThrow(InfrastructureModelMask_I model, string resolutionName);

        System.Type GetBoundUnderlyingTypeOrThrow(SemanticTypeMask_I semanticType);

        BoundTypeDefinitionMask_I GetBoundTypeOrThrow(SemanticTypeMask_I semanticType, bool allowNulls);


        TypeReference GetTypeReference(InfrastructureModelMask_I semanticModel, Type input);

	    TypeReference GetTypeReference(InfrastructureModelMask_I model, Type input, out SemanticTypeDefinitionMask_I possibleSemanticType);


		Type ResolveToType(InfrastructureModelMask_I model, TypeReference typeReference);

        System.Type ResolveToType(InfrastructureModelMask_I model, BoundTypeDefinitionMask_I semanticType);

        System.Type ResolveToType(InfrastructureModelMask_I model, SemanticTypeDefinitionMask_I semanticType, out BoundTypeDefinitionMask_I resultingBound);

	    System.Type ResolveToType(InfrastructureModelMask_I model, TypeReference typeReference, System.Type type, out BoundTypeDefinitionMask_I resultingBound);

		System.Type ResolveToType(InfrastructureModelMask_I model, TypeReference typeReference, out BoundTypeDefinitionMask_I boundType);



		BoundTypeDefinitionMask_I ResolveToBound(InfrastructureModelMask_I model, TypeReference declaringTypeRef);

	    

    }
}
