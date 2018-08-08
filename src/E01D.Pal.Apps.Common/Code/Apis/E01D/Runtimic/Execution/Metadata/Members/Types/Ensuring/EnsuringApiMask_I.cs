using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
    public interface EnsuringApiMask_I
    {
		ArrayApiMask_I Arrays { get;  }

	    ByReferenceApiMask_I ByReferences { get; }

	    DefinitionTypeApiMask_I DefinitionTypes { get; }

		GenericParameterApiMask_I GenericParameters { get; }

	    GenericInstanceTypeApiMask_I GenericInstanceTypes { get; }
		
		PointerApiMask_I Pointers { get; }







		System.Type EnsureToType(RuntimicSystemModel model, TypeReference typeReference);

	    System.Type EnsureToType(ILConversion conversion, TypeReference typeReference);

		System.Type EnsureToType(RuntimicSystemModel model, TypeReference typeReference,
		    out BoundTypeDefinitionMask_I boundType);

	    System.Type EnsureToType(RuntimicSystemModel model, TypeReference typeReference,
		    System.Type underlyingType, out BoundTypeDefinitionMask_I boundType);

	    System.Type EnsureToType(SemanticTypeDefinitionMask_I semanticType);
	    System.Type EnsureToType(ILConversion conversion, TypeReference fieldType, out BoundTypeDefinitionMask_I semanticFieldType);
		System.Type EnsureToType(SemanticTypeDefinitionMask_I semanticType,
		    out BoundTypeDefinitionMask_I resultingBound);
	    ExecutionTypeNode_I Ensure(ExecutionEnsureContext context, TypeReference elementType, bool cloneContext);
		BoundTypeDefinitionMask_I EnsureBound(ExecutionEnsureContext context, TypeReference genericArgument, bool cloneContext);
		BoundTypeDefinitionMask_I EnsureBound(ExecutionEnsureContext context, TypeReference genericArgument);

		//System.Type EnsureToType(RuntimicSystemModel boundType);

		System.Type EnsureToType(ExecutionEnsureContext context);

		BoundTypeDefinitionMask_I EnsureBound(RuntimicSystemModel conversion, TypeReference typeReference);


		BoundTypeDefinitionMask_I EnsureBound(RuntimicSystemModel semanticModel, System.Type type);


	    BoundTypeDefinitionMask_I EnsureBound(RuntimicSystemModel semanticModel, TypeReference typeReference,
		    System.Type type);

	    BoundTypeDefinitionMask_I EnsureBound(ExecutionEnsureContext context);

	    BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, TypeReference typeReference, ConvertedTypeDefinition_I declaringType);

	    BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, TypeReference returnType);

	    BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, Type returnType);


		ExecutionTypeDefinitionMask_I Ensure(RuntimicSystemModel semanticModel, TypeReference input, System.Type underlyingType, BoundTypeDefinitionMask_I declaringType);

	    ExecutionTypeDefinitionMask_I Ensure(ILConversion conversion, TypeReference input, System.Type underlyingType, BoundTypeDefinitionMask_I declaringType);

		/// <summary>
		/// Ensures the type is part of the module.
		/// </summary>
		/// <param name="semanticModel"></param>
		/// <param name="semanticModule"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		ExecutionTypeDefinitionMask_I Ensure(RuntimicSystemModel semanticModel, Type input);



	    

	    ExecutionTypeNode_I Ensure(ExecutionEnsureContext executionEnsureContext);
	    ExecutionTypeNode_I Ensure(ILConversion conversion, TypeReference typeReference, ConvertedTypeDefinition_I declaringType);
	    ExecutionEnsureContext CloneEnvironmentParameters(ExecutionEnsureContext context);
	    
    }
}
