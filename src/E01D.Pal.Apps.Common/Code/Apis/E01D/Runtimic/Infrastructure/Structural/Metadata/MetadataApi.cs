using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Members;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata
{
    public class MetadataApi<TContainer> : RuntimeApiNode<TContainer>, MetadataApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public AssemblyApi_I<TContainer> Assemblies { get; set; }

        AssemblyApiMask_I MetadataApiMask_I.Assemblies => Assemblies;

        public MemberApi_I<TContainer> Members { get; set; }

        MemberApiMask_I MetadataApiMask_I.Members => Members;

        public ModuleApi_I<TContainer> Modules { get; set; }

        ModuleApiMask_I MetadataApiMask_I.Modules => Modules;
    }
}
