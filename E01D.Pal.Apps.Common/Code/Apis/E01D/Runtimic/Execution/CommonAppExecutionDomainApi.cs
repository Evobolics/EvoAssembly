using Root.Code.Apis.E01D.Runtimic.Execution.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution
{
    public class CommonAppExecutionDomainApi
    {
        public MetadataDomainApi Metadata { get; set; } = new MetadataDomainApi();
    }
}
