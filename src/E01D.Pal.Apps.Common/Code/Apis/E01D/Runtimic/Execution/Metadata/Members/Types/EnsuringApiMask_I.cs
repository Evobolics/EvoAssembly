using System;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types
{
    public interface EnsuringApiMask_I
    {
	    BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, Type runtimeReturnType);





	    System.Type EnsureToType(ILConversion conversion, TypeReference typeReference, out BoundTypeDefinitionMask_I boundType);

	    System.Type EnsureToType(ILConversion conversion, TypeReference typeReference);

	    System.Type EnsureToType(ILConversion conversion, SemanticTypeDefinitionMask_I semanticType);

	    // TODO: Rename to GetRuntimeType
	    System.Type EnsureToType(ILConversion conversion, BoundTypeDefinitionMask_I semanticType);

		BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, TypeReference typeReference);


		SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I semanticModel, TypeReference input,
		    System.Type underlyingType, BoundTypeDefinitionMask_I declaringType);


		BoundTypeDefinitionMask_I EnsureBound(BoundRuntimicModelMask_I semanticModel, System.Type type);


	    BoundTypeDefinitionMask_I EnsureBound(BoundRuntimicModelMask_I semanticModel, TypeReference typeReference,
		    System.Type type);

	    /// <summary>
	    /// Ensures the type is part of the module.
	    /// </summary>
	    /// <param name="semanticModel"></param>
	    /// <param name="semanticModule"></param>
	    /// <param name="input"></param>
	    /// <returns></returns>
	    SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I semanticModel, Type input);



	   





    }
}
