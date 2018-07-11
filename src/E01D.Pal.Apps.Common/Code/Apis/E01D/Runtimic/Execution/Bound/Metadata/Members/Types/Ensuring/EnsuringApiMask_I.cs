using System;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
    public interface EnsuringApiMask_I
    {
	    ArrayApiMask_I Arrays { get; }



	    

	    EnumApiMask_I Enums { get; }

	    //GatheringApiMask_I Gathering { get; }

	    GenericInstanceApiMask_I GenericInstances { get; }

	    GenericParameterApiMask_I GenericParameters { get; }

	    NonGenericInstanceApiMask_I NonGenericInstances { get; }

	    PointerApiMask_I Pointers { get; }

	    RequiredModifierApiMask_I RequiredModifiers { get; }

	    void Ensure(InfrastructureModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType);

	    /// <summary>
	    /// Ensures the the is part of the semantic model. The method will search for the type in the model, and if not in the model, adds it.
	    /// </summary>
	    SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, TypeReference typeReference);

	    SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, TypeReference typeReference, Type underlyingType);


	    /// <summary>
	    /// Ensures the the is part of the semantic model. The method will search for the type in the model, and if not in the model, adds it.
	    /// </summary>
	    /// <param name="semanticModel"></param>
	    /// <param name="type"></param>
	    /// <returns></returns>
	    SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, System.Type type);

		/// <summary>
		/// Ensures the type is part of the module.
		/// </summary>
		/// <param name="semanticModel"></param>
		/// <param name="boundModule"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, BoundModule_I boundModule, System.Type input);

	    /// <summary>
	    /// Ensures the type is part of the module.
	    /// </summary>
	    SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, BoundModule_I boundModule,
		    TypeReference input, BoundTypeDefinitionMask_I declaringType, System.Type underlyingType);

	    BoundTypeDefinitionMask_I EnsureBound(InfrastructureModelMask_I semanticModel, System.Type type);


	    BoundTypeDefinitionMask_I EnsureBound(InfrastructureModelMask_I semanticModel, TypeReference typeReference,
		    System.Type type);

		void EnsureTypes(InfrastructureModelMask_I semanticModel, BoundModule_I boundModule);

	    



    }
}
