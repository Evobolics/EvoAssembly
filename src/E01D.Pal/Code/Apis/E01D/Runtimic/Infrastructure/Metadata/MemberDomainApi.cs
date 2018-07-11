using Root.Code.Apis.E01D.Runtimic.Infrastructure.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Metadata
{
    public class MemberDomainApi: MemberDomainApi_I
    {
        public TypalDomainApi_I Typal { get; } = new TypalDomainApi();
    }
}
