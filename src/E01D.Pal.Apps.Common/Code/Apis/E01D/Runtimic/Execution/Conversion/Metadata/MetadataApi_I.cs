using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.CustomAttributes;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata
{
    public interface MetadataApi_I<TContainer>: MetadataApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {
        new AssemblyApi_I<TContainer> Assemblies { get; set; }

	    new CustomAttributeApi_I<TContainer> CustomAttributes { get; set; }

		new MemberApi_I<TContainer> Members { get; set; }

        new ModuleApi_I<TContainer> Modules { get; set; }

        

    }
}
