using Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types.Secondary;

namespace Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types
{
    public class UnifiedTypeDefinitionNode: UnifiedTypePrimaryNode
    {
        public UnifiedPrimaryNodeKind PrimaryNodeKind => UnifiedPrimaryNodeKind.TypeDefinition;

        public UnifiedPointerTypeNode PointerType { get; set; }

        public UnifiedByRefTypeNode ByReferenceType { get; set; }

        public override bool IsPrimary => true;
    }
}
