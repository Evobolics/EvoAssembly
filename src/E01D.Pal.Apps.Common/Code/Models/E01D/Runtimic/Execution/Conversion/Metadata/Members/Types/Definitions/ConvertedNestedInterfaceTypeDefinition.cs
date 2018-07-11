using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public class ConvertedNestedInterfaceTypeDefinition: ConvertedInterfaceTypeDefinition, ConvertedTypeDefinitionWithDeclaringType_I
    {
        public override TypeKind TypeKind => base.TypeKind | TypeKind.Nested;
        public ConvertedTypeDefinitionMask_I DeclaringType { get; set; }
        SemanticTypeMask_I SemanticMemberWithDeclaringTypeMask_I.DeclaringType => DeclaringType;
        BoundTypeDefinitionMask_I BoundMemberWithDeclaringTypeMask_I.DeclaringType => DeclaringType;


    }
}
