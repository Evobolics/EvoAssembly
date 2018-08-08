using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using GatheringApiMask_I = Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering.GatheringApiMask_I;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public interface EnsuringApiMask_I
    {
        //ArrayApiMask_I Arrays { get; }



        DotNetApiMask_I DotNet { get; }

        EnumApiMask_I Enums { get; }

        GatheringApiMask_I Gathering { get; }

        GenericInstancesApiMask_I Generic { get; }

        GenericParameterApiMask_I GenericParameters { get; }

        NonGenericInstanceApiMask_I NonGenericInstances { get; }

	    //UnifiedApiMask_I Unified { get; }


	    bool EnsurePhase3Type(ILConversion conversion,
			ConvertedTypeDefinitionMask_I routineDeclaringType,
			MethodDefinition methodDefinition,
			TypeReference typeReference,
			out BoundTypeDefinitionMask_I type);
		SemanticTypeDefinitionMask_I Ensure(ILConversion conversion, TypeReference input, ConvertedTypeDefinition_I declaringType);


		
	}
}
