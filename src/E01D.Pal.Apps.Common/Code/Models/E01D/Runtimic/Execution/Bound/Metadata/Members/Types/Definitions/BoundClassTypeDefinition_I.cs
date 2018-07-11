using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
	public interface BoundClassTypeDefinition_I:
		BoundClassTypeDefinitionMask_I,
		SemanticTypeWithInterfaceTypeList_I,
		BoundTypeDefinitionWithFields_I,
		BoundTypeDefinitionWithMethods_I,
		BoundTypeDefinitionWithConstructors_I,
		BoundTypeDefinitionWithEvents_I,
		BoundTypeDefinitionWithProperties_I
	{

	}
}
