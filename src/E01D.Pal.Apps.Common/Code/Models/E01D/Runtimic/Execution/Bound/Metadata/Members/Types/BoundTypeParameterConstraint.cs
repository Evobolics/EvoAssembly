using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	public abstract class BoundTypeParameterConstraint : BoundTypeParameterConstraintMask_I
	{
		public TypeParameterConstraintKind Attributes { get; set; }

		public abstract SemanticTypeDefinitionMask_I SemanticType { get; }
		SemanticTypeMask_I SemanticGenericParameterTypeDefinitionConstraintMask_I.SemanticType => SemanticType;


	}
}
