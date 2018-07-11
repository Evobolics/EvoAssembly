using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Modules;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Assemblies;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public interface MetadataApiMask_I
    {
        AssemblyApiMask_I Assemblies { get; }

        MemberApiMask_I Members { get; }

        ModuleApiMask_I Modules { get; }
    }
}
