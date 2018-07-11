using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public abstract class BoundGenericParameterTypeDefinitionConstraint: BoundGenericParameterTypeDefinitionConstraintMask_I
    {
	    public TypeParameterConstraintKind Attributes { get; set; }
		public abstract BoundTypeMask_I SemanticType { get;  }
        SemanticTypeMask_I SemanticGenericParameterTypeDefinitionConstraintMask_I.SemanticType => SemanticType;
    }
}
