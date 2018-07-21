using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundDelegateTypeDefinition : BoundReferenceTypeDefinition, BoundDelegateTypeDefinitionMask_I, BoundTypeDefinitionWithFields_I, BoundTypeDefinitionWithMethodsMask_I,
	    BoundTypeDefinitionWithConstructorsMask_I
	{
		public BoundTypeDefinitionConstructors Constructors { get; set; } = new BoundTypeDefinitionConstructors();

		public BoundTypeDefinitionFields Fields { get; set; } = new BoundTypeDefinitionFields();

		public BoundTypeDefinitionMethods Methods { get; set; } = new BoundTypeDefinitionMethods();

		

		public override TypeKind TypeKind => base.TypeKind | TypeKind.Delegate;

		SemanticTypeConstructorsMask_I SemanticTypeWithConstructorsMask_I.Constructors => this.Constructors;

		SemanticTypeFieldsMask_I SemanticTypeDefinitionWithFieldsMask_I.Fields => Fields;

		SemanticTypeMethodsMask_I SemanticTypeWithMethodsMask_I.Methods => this.Methods;

		

	}
}
