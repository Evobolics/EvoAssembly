using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic
{
    public class SemanticApi<TContainer> : SemanticApiNode<TContainer>, SemanticApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public MetadataApi_I<TContainer> Metadata { get; set; }

        MetadataApiMask_I SemanticApiMask_I.Metadata => Metadata;

        
    }
}
