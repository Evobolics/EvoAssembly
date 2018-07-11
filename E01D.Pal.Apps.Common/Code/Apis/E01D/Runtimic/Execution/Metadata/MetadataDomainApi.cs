using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Assemblies;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata
{
    public class MetadataDomainApi
    {
        public AssemblyDomainApi Assemblies { get; set; } = new AssemblyDomainApi();
    }
}
