using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Modules;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Assemblies;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata
{
    public interface MetadataApi_I<TContainer>: MetadataApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {
        new AssemblyApi_I<TContainer> Assemblies { get; set; }

        new MemberApi_I<TContainer> Members { get; set; }

        new ModuleApi_I<TContainer> Modules { get; set; }

        

    }
}
