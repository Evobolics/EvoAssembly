using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{
	public interface ExecutionGenericTypeDefinitionMask_I: ExecutionTypeDefinitionMask_I, SemanticGenericTypeDefinitionMask_I
	{
		new ExecutionGenericTypeDefinitionGenericTypeArgumentsMask_I TypeArguments { get; }
	}
}
