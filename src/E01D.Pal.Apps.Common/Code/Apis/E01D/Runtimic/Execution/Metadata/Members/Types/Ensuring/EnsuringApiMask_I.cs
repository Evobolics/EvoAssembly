using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
    public interface EnsuringApiMask_I
    {
		ArrayApiMask_I Arrays { get;  }

	    ByReferenceApiMask_I ByReferences { get; }

	    GenericParameterApiMask_I GenericParameters { get; }

		PointerApiMask_I Pointers { get; }







		System.Type EnsureToType(BoundRuntimicModelMask_I model, TypeReference typeReference);

	    System.Type EnsureToType(BoundRuntimicModelMask_I model, TypeReference typeReference,
		    out BoundTypeDefinitionMask_I boundType);

	    System.Type EnsureToType(BoundRuntimicModelMask_I model, TypeReference typeReference,
		    System.Type underlyingType, out BoundTypeDefinitionMask_I boundType);

	    System.Type EnsureToType(SemanticTypeDefinitionMask_I semanticType);

	    System.Type EnsureToType(SemanticTypeDefinitionMask_I semanticType,
		    out BoundTypeDefinitionMask_I resultingBound);

	    System.Type EnsureToType(BoundTypeDefinitionMask_I boundType);

	    System.Type EnsureToType(BoundRuntimicModelMask_I model, BoundEnsureContext context);

		BoundTypeDefinitionMask_I EnsureBound(BoundRuntimicModelMask_I conversion, TypeReference typeReference);


		BoundTypeDefinitionMask_I EnsureBound(BoundRuntimicModelMask_I semanticModel, System.Type type);


	    BoundTypeDefinitionMask_I EnsureBound(BoundRuntimicModelMask_I semanticModel, TypeReference typeReference,
		    System.Type type);

	    SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I semanticModel, TypeReference input, System.Type underlyingType, BoundTypeDefinitionMask_I declaringType);

		/// <summary>
		/// Ensures the type is part of the module.
		/// </summary>
		/// <param name="semanticModel"></param>
		/// <param name="semanticModule"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I semanticModel, Type input);

	    SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I boundModel, BoundEnsureContext context);

	    









	}
}
