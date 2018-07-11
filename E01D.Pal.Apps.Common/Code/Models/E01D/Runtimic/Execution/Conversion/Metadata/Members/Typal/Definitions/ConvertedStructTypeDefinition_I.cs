using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public interface ConvertedStructTypeDefinition_I : 
        ConvertedNonEnumTypePart_I, 
        SemanticTypeWithInterfaceTypeList_I,
        ConvertedTypeDefinitionWithConstructors_I,
        ConvertedTypeDefinitionWithEvents_I,
        ConvertedTypeDefinitionWithFields_I,
        ConvertedTypeDefinitionWithMethods_I,
        ConvertedTypeDefinitionWithProperties_I
    {
    }
}
