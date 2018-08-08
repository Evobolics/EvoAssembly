using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
    public interface GenericParameterApiMask_I
    {
        SemanticTypeDefinitionMask_I Ensure(RuntimicSystemModel boundModel, ExecutionEnsureContext context);

        ExecutionTypeNode_I Ensure(ExecutionEnsureContext context);
    }
}
