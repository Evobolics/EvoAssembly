using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface InformationApi_I<TContainer> : InformationApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {

    }
}
