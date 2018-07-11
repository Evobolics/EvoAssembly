using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata
{
    public interface MetadataApiMask_I
    {
        AssemblyApiMask_I Assemblies { get;  }

        MemberApiMask_I Members { get;  }

        ModuleApiMask_I Modules { get;  }
    }
}
