using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata
{
    public interface MetadataApiMask_I
    {
        AssemblyApiMask_I Assemblies { get;  }

	    MemberApiMask_I Members { get; }


	}
}
