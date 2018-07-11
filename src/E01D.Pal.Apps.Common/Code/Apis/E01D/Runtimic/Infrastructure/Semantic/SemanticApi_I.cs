using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic
{
    public interface SemanticApi_I<TContainer> : SemanticApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new MetadataApi_I<TContainer> Metadata { get; set; }

        
    }
}
