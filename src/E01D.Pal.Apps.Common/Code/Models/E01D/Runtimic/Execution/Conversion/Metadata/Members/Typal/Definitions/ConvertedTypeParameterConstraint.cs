using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal
{
    public abstract class ConvertedTypeParameterConstraint : CovertedTypeParameterConstraintMask_I
    {
        public TypeParameterConstraintKind Attributes { get; set; }

        public abstract SemanticTypeDefinitionMask_I SemanticType { get; }
        SemanticTypeMask_I SemanticParameterTypeDefinitionConstraintMask_I.SemanticType => SemanticType;

        
    }
}
