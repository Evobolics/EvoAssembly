using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public interface MetadataApi_I<TContainer> : MetadataApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new MemberApi_I<TContainer> Members { get; set; }
    }
}
