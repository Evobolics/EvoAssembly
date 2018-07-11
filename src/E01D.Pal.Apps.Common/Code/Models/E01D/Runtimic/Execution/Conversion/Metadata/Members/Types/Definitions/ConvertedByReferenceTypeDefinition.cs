using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
	public class ConvertedByReferenceTypeDefinition: ConvertedReferenceOrValueTypeDefinition, ConvertedByReferenceTypeDefinitionMask_I
	{
		public override TypeKind TypeKind => base.TypeKind | TypeKind.ByRef;

		public SemanticTypeDefinitionMask_I ElementType { get; set; }
	}
}
