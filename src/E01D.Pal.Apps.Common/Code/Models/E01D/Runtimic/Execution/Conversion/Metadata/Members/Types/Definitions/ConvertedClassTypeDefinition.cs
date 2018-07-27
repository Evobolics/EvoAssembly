using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public class ConvertedClassTypeDefinition: ConvertedReferenceTypeDefinition, ConvertedClassTypeDefinition_I
    {
        public ConvertedTypeDefinitionConstructors Constructors { get; set; } = new ConvertedTypeDefinitionConstructors();

        public ConvertedTypeDefinitionEvents Events { get; set; } = new ConvertedTypeDefinitionEvents();

        public ConvertedTypeDefinitionFields Fields { get; set; } = new ConvertedTypeDefinitionFields();

        public SemanticTypeDefinitionInterfaces Interfaces { get; set; } = new SemanticTypeDefinitionInterfaces();

        public ConvertedTypeDefinitionProperties Properties { get; set; } = new ConvertedTypeDefinitionProperties();

        public override TypeKind TypeKind => base.TypeKind | TypeKind.Class | TypeKind.SupportsInterfaceTypeList;

        SemanticTypeConstructorsMask_I SemanticTypeWithConstructorsMask_I.Constructors => this.Constructors;

        SemanticTypeFieldsMask_I SemanticTypeDefinitionWithFieldsMask_I.Fields => this.Fields;

        SemanticTypeEventsMask_I SemanticTypeWithEventsMask_I.Events => this.Events;

        SemanticTypeDefinitionInterfacesMask_I SemanticTypeWithInterfaceTypeListMask_I.Interfaces => Interfaces;

        SemanticTypePropertiesMask_I SemanticTypeWithPropertiesMask_I.Properties => this.Properties;

        
    }
}
