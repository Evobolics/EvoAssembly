using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata
{
    public interface MetadataApiMask_I
    {
        MemberApiMask_I Members { get; }
        ModuleApiMask_I Modules { get; }

        AssemblyApiMask_I Assemblies { get; }
    }
}
