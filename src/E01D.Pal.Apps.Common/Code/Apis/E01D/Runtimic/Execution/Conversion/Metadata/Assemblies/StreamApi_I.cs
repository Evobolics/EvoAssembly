using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public interface StreamApi_I<TContainer> : StreamApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        
    }
}
