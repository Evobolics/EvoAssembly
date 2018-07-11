using System;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using GatheringApiMask_I = Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering.GatheringApiMask_I;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public interface EnsuringApiMask_I
    {
        ArrayApiMask_I Arrays { get; }



        DotNetApiMask_I DotNet { get; }

        EnumApiMask_I Enums { get; }

        GatheringApiMask_I Gathering { get; }

        GenericInstancesApiMask_I Generic { get; }

        GenericParameterApiMask_I GenericParameters { get; }

        NonGenericInstanceApiMask_I NonGenericInstances { get; }

	    BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, Type runtimeReturnType);

		BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, TypeReference typeReference);

	    

		System.Type EnsureToType(ILConversion conversion, TypeReference typeReference,out BoundTypeDefinitionMask_I boundType);

	    System.Type EnsureToType(ILConversion conversion, TypeReference typeReference);

	    System.Type EnsureToType(ILConversion conversion, SemanticTypeDefinitionMask_I semanticType);

	    // TODO: Rename to GetRuntimeType
	    System.Type EnsureToType(ILConversion conversion, BoundTypeDefinitionMask_I semanticType);

	    void Ensure(ILConversion conversion, ConvertedTypeDefinition_I semanticType);

		SemanticTypeDefinitionMask_I Ensure(ILConversion conversion, TypeReference typeReference,  SemanticTypeDefinitionMask_I declaringType);

		SemanticTypeDefinitionMask_I Ensure(ILConversion conversion, ConvertedModule_I module, System.Type input);

        SemanticTypeDefinitionMask_I Ensure(ILConversion conversion, ConvertedModule_I module, TypeReference input, ConvertedTypeDefinition_I declaringType);
		
	}
}
