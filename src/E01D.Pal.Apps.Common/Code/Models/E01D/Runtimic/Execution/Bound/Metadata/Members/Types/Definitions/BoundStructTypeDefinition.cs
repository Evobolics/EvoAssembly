using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundStructTypeDefinition : BoundValueTypeDefinition, BoundTypeDefinitionWithFields_I, BoundTypeDefinitionWithMethods_I, BoundTypeDefinitionWithConstructors_I
	{
		public BoundTypeDefinitionConstructors Constructors { get; set; } = new BoundTypeDefinitionConstructors();

		SemanticTypeConstructorsMask_I SemanticTypeWithConstructorsMask_I.Constructors => this.Constructors;

		public BoundTypeDefinitionFields Fields { get; set; } = new BoundTypeDefinitionFields();

		SemanticTypeFieldsMask_I SemanticTypeDefinitionWithFieldsMask_I.Fields => Fields;

		public BoundTypeDefinitionMethods Methods { get; set; } = new BoundTypeDefinitionMethods();

		SemanticTypeMethodsMask_I SemanticTypeWithMethodsMask_I.Methods => Methods;

		public override TypeKind TypeKind => base.TypeKind | TypeKind.Struct;

		

	}
}
