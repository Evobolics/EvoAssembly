using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
    public interface ArrayApiMask_I
    {
		//SemanticTypeDefinitionMask_I Ensure(RuntimicSystemModel semanticModel, TypeReference input, BoundTypeDefinitionMask_I declaringType, System.Type underlyingType);

	    ExecutionTypeNode_I Ensure(ExecutionEnsureContext context);
	}
}
