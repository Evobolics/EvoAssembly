using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public class ConvertedNestedDelegateTypeDefinition: ConvertedDelegateTypeDefinition, ConvertedTypeDefinitionWithDeclaringType_I, ConvertedDelegateTypeDefinitionMask_I
    {
        public ConvertedTypeDefinitionMask_I DeclaringType { get; set; }
        SemanticTypeMask_I SemanticMemberWithDeclaringTypeMask_I.DeclaringType => DeclaringType;
        BoundTypeMask_I BoundMemberWithDeclaringTypeMask_I.DeclaringType => DeclaringType;

        public override TypeKind TypeKind => base.TypeKind | TypeKind.Nested;
        
    }
}
