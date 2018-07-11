using Root.Code.Domains.E01D;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata;

namespace Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata
{
    public static class AssemblyExts
    {
        public static string ResolutionName(this Assembly_I assembly)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Assemblies.ResolutionName(assembly);
        }


    }
}
