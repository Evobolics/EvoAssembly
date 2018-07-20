using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members
{
    public interface SemanticFieldMask_I: SemanticMemberMask_I
    {
        SemanticTypeMask_I FieldType { get; }

        FieldDefinition FieldDefinition { get;  }
    }
}
