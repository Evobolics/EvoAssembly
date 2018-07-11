using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
	public class BoundField : BoundMember, BoundFieldDefinitionMask_I, BoundMemberWithDeclaringType_I
	{
		
		public BoundTypeMask_I FieldType { get; set; }

		public FieldDefinition FieldDefinition { get; set; }

		SemanticTypeMask_I SemanticFieldMask_I.FieldType => FieldType;

		public BoundTypeDefinitionMask_I DeclaringType { get; set; }
		SemanticTypeMask_I SemanticMemberWithDeclaringTypeMask_I.DeclaringType => DeclaringType;
		BoundTypeDefinitionMask_I BoundMemberWithDeclaringTypeMask_I.DeclaringType => DeclaringType;

		public FieldInfo UnderlyingField { get; set; }
		public MemberInfo UnderlyingMember => UnderlyingField;
	}
}
