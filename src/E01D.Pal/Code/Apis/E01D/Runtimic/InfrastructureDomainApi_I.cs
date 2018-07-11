using Root.Code.Apis.E01D.Runtimic.Infrastructure;
using Root.Code.Attributes.E01D;

namespace Root.Code.Apis.E01D.Runtimic
{
    [StaticApi]
    [PhenotypeMask]
    public interface InfrastructureDomainApi_I
    {
        MetadataDomainApi_I Metadata { get; }
    }
}
