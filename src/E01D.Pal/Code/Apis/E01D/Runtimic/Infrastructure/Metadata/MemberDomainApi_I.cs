using Root.Code.Apis.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Attributes.E01D;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Metadata
{
    [StaticApi]
    [PhenotypeMask]
    public interface MemberDomainApi_I
    {
        TypalDomainApi_I Typal { get; }
    }
}
