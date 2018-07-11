using System.Reflection;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface BoundMemberDefinitionMask_I: BoundMemberMask_I
    {
        MemberInfo UnderlyingMember { get; }
    }
}
