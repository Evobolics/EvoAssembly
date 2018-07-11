using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.CustomAttributes;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata
{
    public interface MetadataApiMask_I
    {
        AssemblyApiMask_I Assemblies { get;  }

	    CustomAttributeApiMask_I CustomAttributes { get; }

		MemberApiMask_I Members { get;  }

        ModuleApiMask_I Modules { get;  }
    }
}
