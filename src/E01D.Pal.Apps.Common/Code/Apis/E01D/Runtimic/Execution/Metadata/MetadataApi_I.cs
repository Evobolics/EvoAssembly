

using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Assemblies;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata
{
    public interface MetadataApi_I<TContainer>: MetadataApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {
        new AssemblyApi_I<TContainer> Assemblies { get; set; }



        
    }
}
