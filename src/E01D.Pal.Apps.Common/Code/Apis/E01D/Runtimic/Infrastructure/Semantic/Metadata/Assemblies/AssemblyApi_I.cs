using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Assemblies
{
    public interface AssemblyApi_I<TContainer> : AssemblyApiMask_I
        where TContainer :RuntimicContainer_I<TContainer>
    {
        
    }
}
