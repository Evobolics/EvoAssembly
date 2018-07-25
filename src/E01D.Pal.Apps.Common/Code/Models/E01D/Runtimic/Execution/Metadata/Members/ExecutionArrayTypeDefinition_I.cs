using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{
	public interface ExecutionArrayTypeDefinition_I: ExecutionTypeDefinition_I, ExecutionArrayTypeDefinitionMask_I
	{
		new SemanticTypeDefinitionMask_I ElementType { get; set; }
	}
}
