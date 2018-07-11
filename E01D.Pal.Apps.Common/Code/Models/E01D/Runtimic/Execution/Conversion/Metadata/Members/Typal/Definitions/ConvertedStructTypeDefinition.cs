using System.Reflection.Emit;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
	public class ConvertedStructTypeDefinition:ConvertedValueTypeDefinition, ConvertedStructTypeDefinition_I
    {
	    public override TypeKind TypeKind => base.TypeKind | TypeKind.Struct;
        
        

        public SemanticTypeDefinitionInterfaces Interfaces { get; set; } = new SemanticTypeDefinitionInterfaces();

        SemanticTypeDefinitionInterfacesMask_I SemanticTypeWithInterfaceTypeListMask_I.Interfaces => Interfaces;

        public ConvertedTypeDefinitionConstructors Constructors { get; set; } = new ConvertedTypeDefinitionConstructors();

        public ConvertedTypeDefinitionEvents Events { get; set; } = new ConvertedTypeDefinitionEvents();

        public ConvertedTypeDefinitionFields Fields { get; set; } = new ConvertedTypeDefinitionFields();

        public GenericTypeParameterBuilder[] GenericTypeParameters { get; set; }

        public ConvertedTypeDefinitionMethods Methods { get; set; } = new ConvertedTypeDefinitionMethods();

        public ConvertedTypeDefinitionProperties Properties { get; set; } = new ConvertedTypeDefinitionProperties();

        SemanticTypeConstructorsMask_I SemanticTypeWithConstructorsMask_I.Constructors => this.Constructors;

        SemanticTypeEventsMask_I SemanticTypeWithEventsMask_I.Events => this.Events;

        SemanticTypeFieldsMask_I SemanticTypeDefinitionWithFieldsMask_I.Fields => this.Fields;

        SemanticTypeMethodsMask_I SemanticTypeWithMethodsMask_I.Methods => this.Methods;

        SemanticTypePropertiesMask_I SemanticTypeWithPropertiesMask_I.Properties => this.Properties;

        public MethodBuilder MethodBuilder { get; set; }
    }
}
