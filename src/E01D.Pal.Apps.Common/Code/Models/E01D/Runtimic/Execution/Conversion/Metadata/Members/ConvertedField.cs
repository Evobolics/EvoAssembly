using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public class ConvertedField:ConvertedMember, ConvertedFieldMask_I, ConvertedMemberWithDeclaringType_I
    {
        public FieldBuilder FieldBuilder { get; set; }
        public BoundTypeMask_I FieldType { get; set; }
        
        public FieldDefinition FieldDefinition { get; set; }

        SemanticTypeMask_I SemanticFieldMask_I.FieldType => FieldType;

        public ConvertedTypeDefinitionMask_I DeclaringType { get; set; }
        SemanticTypeMask_I SemanticMemberWithDeclaringTypeMask_I.DeclaringType => DeclaringType;
	    BoundTypeDefinitionMask_I BoundMemberWithDeclaringTypeMask_I.DeclaringType => DeclaringType;

        public FieldInfo UnderlyingField { get; set; }
        public MemberInfo UnderlyingMember => UnderlyingField;
    }
}
