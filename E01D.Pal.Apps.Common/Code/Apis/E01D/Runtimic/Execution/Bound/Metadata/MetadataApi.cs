using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Modules;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata
{
    public class MetadataApi<TContainer> : BindingApiNode<TContainer>, MetadataApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public new AssemblyApi_I<TContainer> Assemblies { get; set; }
        
        public new MemberApi_I<TContainer> Members { get; set; }
        public new ModuleApi_I<TContainer> Modules { get; set; }

        AssemblyApiMask_I MetadataApiMask_I.Assemblies => Assemblies;

        MemberApiMask_I MetadataApiMask_I.Members => Members;
        ModuleApiMask_I MetadataApiMask_I.Modules => Modules;
        
    }
}
