using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedClassTypeDefinition_I:
        ConvertedClassTypeDefinitionMask_I,
        SemanticTypeWithInterfaceTypeList_I,
        ConvertedTypeDefinitionWithFields_I,
        ConvertedTypeDefinitionWithMethods_I,
        ConvertedTypeDefinitionWithConstructors_I,
        ConvertedTypeDefinitionWithEvents_I,
        ConvertedTypeDefinitionWithProperties_I
    {
        new ConvertedTypeDefinitionConstructors Constructors { get; set; }

        new ConvertedTypeDefinitionEvents Events { get; set; }

        new ConvertedTypeDefinitionFields Fields { get; set; }

        new ConvertedTypeDefinitionMethods Methods { get; set; }

        

        new ConvertedTypeDefinitionProperties Properties { get; set; }
    }
}
