using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata
{
    public interface MetadataApi_I<TContainer>: MetadataApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {
        new AssemblyApi_I<TContainer> Assemblies { get; set; }

        new MemberApi_I<TContainer> Members { get; set; }

        new ModuleApi_I<TContainer> Modules { get; set; }

        

    }
}
