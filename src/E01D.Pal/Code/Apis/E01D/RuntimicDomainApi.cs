using Root.Code.Apis.E01D.Runtimic;
using Root.Code.Attributes.E01D;

namespace Root.Code.Apis.E01D
{
    public class RuntimicDomainApi
    {
        [DynamicallyReplaceWithContainerApi]
        public InfrastructureDomainApi Infrastructure { get; set; } = new InfrastructureDomainApi();
    }
}
