using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
	public interface DefinitionTypeApiMask_I
	{
		ExecutionTypeNode_I Ensure(ExecutionEnsureContext context);
	}
}
