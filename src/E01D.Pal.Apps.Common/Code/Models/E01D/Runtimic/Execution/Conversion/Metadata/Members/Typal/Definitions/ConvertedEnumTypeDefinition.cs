using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public class ConvertedEnumTypeDefinition: ConvertedValueTypeDefinition, ConvertedEnumTypePart_I
    {
        

        public override TypeKind TypeKind => base.TypeKind | TypeKind.Enum;
    }
}
