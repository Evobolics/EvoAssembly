using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Modules;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Assemblies;
namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public class MetadataApi<TContainer> : SemanticApiNode<TContainer>, MetadataApi_I<TContainer>
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
