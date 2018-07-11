using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundStructTypeDefinition : BoundValueTypeDefinition, BoundNonEnumTypePart_I, BoundTypeDefinitionWithFields_I
	{
		public BoundTypeDefinitionFields Fields { get; set; } = new BoundTypeDefinitionFields();

		SemanticTypeFieldsMask_I SemanticTypeDefinitionWithFieldsMask_I.Fields => Fields;

		public override TypeKind TypeKind => base.TypeKind | TypeKind.Struct;
        
    }
}
