using Root.Code.Apis.E01D.Runtimic.Infrastructure;
using Root.Code.Attributes.E01D;

namespace Root.Code.Apis.E01D.Runtimic
{
    [StaticApi]
    public class InfrastructureDomainApi: InfrastructureDomainApi_I
    {
        [DynamicallyReplaceWithContainerApi]
        public MetadataDomainApi_I Metadata { get; set; } = new MetadataDomainApi();
    }
}
