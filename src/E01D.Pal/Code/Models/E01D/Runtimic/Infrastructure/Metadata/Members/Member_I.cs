using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members
{
    public interface Member_I: Metadata_I, MemberMask_I
    {
       MemberKind MemberKind { get; }

        
    }
}
