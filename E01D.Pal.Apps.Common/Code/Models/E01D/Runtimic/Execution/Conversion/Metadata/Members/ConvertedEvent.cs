using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public class ConvertedEvent : ConvertedMember, ConvertedEventMask_I, ConvertedMemberWithDeclaringType_I
    {
        public EventBuilder Builder { get; set; }

        public ConvertedTypeDefinitionMask_I DeclaringType { get; set; }
        SemanticTypeMask_I SemanticMemberWithDeclaringTypeMask_I.DeclaringType => DeclaringType;
	    BoundTypeDefinitionMask_I BoundMemberWithDeclaringTypeMask_I.DeclaringType => DeclaringType;
        
        public MemberInfo UnderlyingMember => null;
	    public EventDefinition EventDefinition { get; set; }
    }
}
