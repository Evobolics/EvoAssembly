using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundClassTypeDefinition: BoundReferenceTypeDefinition, BoundTypeWithBaseType_I, BoundClassTypeDefinition_I
	{
        public new SemanticTypeMask_I BaseType { get; set; }

        public override TypeKind TypeKind => base.TypeKind | TypeKind.Class;

	    public BoundTypeDefinitionConstructors Constructors { get; set; } = new BoundTypeDefinitionConstructors();

		public BoundTypeDefinitionFields Fields { get; set; } = new BoundTypeDefinitionFields();

		public SemanticTypeDefinitionInterfaces Interfaces { get; set; } = new SemanticTypeDefinitionInterfaces();

		SemanticTypeDefinitionInterfacesMask_I SemanticTypeWithInterfaceTypeListMask_I.Interfaces => Interfaces;

		public BoundTypeDefinitionMethods Methods { get; set; } = new BoundTypeDefinitionMethods();

	    public BoundTypeDefinitionEvents Events { get; set; } = new BoundTypeDefinitionEvents();

	    public BoundTypeDefinitionProperties Properties { get; set; } = new BoundTypeDefinitionProperties();

	    SemanticTypeConstructorsMask_I SemanticTypeWithConstructorsMask_I.Constructors => this.Constructors;

	    SemanticTypeFieldsMask_I SemanticTypeDefinitionWithFieldsMask_I.Fields => this.Fields;

	    SemanticTypeMethodsMask_I SemanticTypeWithMethodsMask_I.Methods => this.Methods;

	    SemanticTypeEventsMask_I SemanticTypeWithEventsMask_I.Events => this.Events;

	    SemanticTypePropertiesMask_I SemanticTypeWithPropertiesMask_I.Properties => this.Properties;



	}
}
