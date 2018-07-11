using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
	public class ConvertedPointerTypeDefinition:ConvertedTypeDefinition
	{
		public override TypeKind TypeKind => base.TypeKind | TypeKind.Pointer;
	}
}
