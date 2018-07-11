using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Metadata
{
    public class AssemblyDomainApi
    {
        public string ResolutionName(Assembly_I assembly)
        {
            return assembly.FullName;
        }
    }
}
