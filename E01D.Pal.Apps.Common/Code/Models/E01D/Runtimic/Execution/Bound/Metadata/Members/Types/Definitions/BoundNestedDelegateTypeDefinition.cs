using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundNestedDelegateTypeDefinition : BoundDelegateTypeDefinition, BoundTypeDefinitionWithDeclaringType_I
    {
        public override TypeKind TypeKind => base.TypeKind | TypeKind.Nested;
        public BoundTypeDefinitionMask_I DeclaringType { get; set; }


        SemanticTypeMask_I SemanticMemberWithDeclaringTypeMask_I.DeclaringType => DeclaringType;
    }
}
