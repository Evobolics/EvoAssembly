using Root.Code.Apis.E01D.Runtimic.Execution;

namespace Root.Code.Apis.E01D.Runtimic
{
    public class CommonAppRuntimicDomainApi
    {
        public CommonAppExecutionDomainApi Execution { get; set; } = new CommonAppExecutionDomainApi();
    }
}
