using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.CustomAttributes;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Signatures;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class MetadataApi<TContainer> : ConversionApiNode<TContainer>, MetadataApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        

	    

		
        

        public new AssemblyApi_I<TContainer> Assemblies { get; set; }

        AssemblyApiMask_I MetadataApiMask_I.Assemblies => Assemblies;

        public new CustomAttributeApi_I<TContainer> CustomAttributes { get; set; }

        CustomAttributeApiMask_I MetadataApiMask_I.CustomAttributes => CustomAttributes;

        public new MemberApi_I<TContainer> Members { get; set; }
        MemberApiMask_I MetadataApiMask_I.Members => Members;

        public new ModuleApi_I<TContainer> Modules { get; set; }

        ModuleApiMask_I MetadataApiMask_I.Modules
        {
            get { return Modules; }
        }

        public new SignatureApi_I<TContainer> Signatures { get; set; }
        SignatureApiMask_I MetadataApiMask_I.Signatures => Signatures;

    }
}
