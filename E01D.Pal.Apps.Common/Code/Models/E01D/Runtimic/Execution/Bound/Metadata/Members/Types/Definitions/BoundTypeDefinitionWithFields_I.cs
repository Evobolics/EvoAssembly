using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
	public interface BoundTypeDefinitionWithFields_I: BoundTypeDefinition_I, BoundTypeDefinitionWithFieldsMask_I
	{
		new BoundTypeDefinitionFields Fields { get; set; }
	}
}
