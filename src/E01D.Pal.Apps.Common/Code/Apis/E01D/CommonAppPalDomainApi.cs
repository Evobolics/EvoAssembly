using Root.Code.Apis.E01D.Activation;
using Root.Code.Apis.E01D.Containment;
using Root.Code.Apis.E01D.Runtimic;

namespace Root.Code.Apis.E01D
{
    public class CommonAppPalDomainApi
    {
        public CommonAppActivationDomainApi Activation { get; set; } = new CommonAppActivationDomainApi();

        public CommonAppContainerDomainApi Containment { get; set; } = new CommonAppContainerDomainApi();
        public CommonAppRuntimicDomainApi Runtimic { get; set; } = new CommonAppRuntimicDomainApi();
    }
}
