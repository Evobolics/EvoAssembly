using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
	public class BoundRequiredModifierTypeDefinition:BoundTypeDefinition
	{
		public override TypeKind TypeKind => base.TypeKind | TypeKind.RequiredModifier;
	}
}
