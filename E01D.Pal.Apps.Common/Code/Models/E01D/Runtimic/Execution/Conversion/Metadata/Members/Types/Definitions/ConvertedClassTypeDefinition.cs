using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public class ConvertedClassTypeDefinition: ConvertedReferenceTypeDefinition, ConvertedClassTypeDefinition_I
    {

        public override TypeKind TypeKind => base.TypeKind | TypeKind.Class | TypeKind.SupportsInterfaceTypeList;

        public SemanticTypeDefinitionInterfaces Interfaces { get; set; } = new SemanticTypeDefinitionInterfaces();

        SemanticTypeDefinitionInterfacesMask_I SemanticTypeWithInterfaceTypeListMask_I.Interfaces => Interfaces;

        public ConvertedTypeDefinitionConstructors Constructors { get; set; } = new ConvertedTypeDefinitionConstructors();

        public ConvertedTypeDefinitionFields Fields { get; set; } = new ConvertedTypeDefinitionFields();

        public ConvertedTypeDefinitionMethods Methods { get; set; } = new ConvertedTypeDefinitionMethods();

        public ConvertedTypeDefinitionEvents Events { get; set; } = new ConvertedTypeDefinitionEvents();

        public ConvertedTypeDefinitionProperties Properties { get; set; } = new ConvertedTypeDefinitionProperties();

        SemanticTypeConstructorsMask_I SemanticTypeWithConstructorsMask_I.Constructors => this.Constructors;

        SemanticTypeFieldsMask_I SemanticTypeDefinitionWithFieldsMask_I.Fields => this.Fields;

        SemanticTypeMethodsMask_I SemanticTypeWithMethodsMask_I.Methods => this.Methods;

        SemanticTypeEventsMask_I SemanticTypeWithEventsMask_I.Events => this.Events;

        SemanticTypePropertiesMask_I SemanticTypeWithPropertiesMask_I.Properties => this.Properties;

        
    }
}
