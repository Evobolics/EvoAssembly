using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
	public interface BoundGenericParameterTypeDefinition_I: BoundGenericParameterTypeDefinitionMask_I
	{
		new GenericParameter Definition { get; set; }
		new System.Type UnderlyingType { get; set; }
	}
}
