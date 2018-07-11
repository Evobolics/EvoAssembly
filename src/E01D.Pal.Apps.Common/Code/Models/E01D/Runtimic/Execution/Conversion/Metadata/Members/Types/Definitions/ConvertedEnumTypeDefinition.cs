using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public class ConvertedEnumTypeDefinition: ConvertedValueTypeDefinition,  ConvertedTypeDefinitionWithFields_I
    {

		public ConvertedTypeDefinitionFields Fields { get; set; } = new ConvertedTypeDefinitionFields();

	    SemanticTypeFieldsMask_I SemanticTypeDefinitionWithFieldsMask_I.Fields => Fields;


		public override TypeKind TypeKind => base.TypeKind | TypeKind.Enum;
    }
}
