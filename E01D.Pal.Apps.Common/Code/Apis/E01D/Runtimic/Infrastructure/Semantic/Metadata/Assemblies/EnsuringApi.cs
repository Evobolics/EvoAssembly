using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Assemblies
{
    public class EnsuringApi<TContainer> : SemanticApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        
    }
}
