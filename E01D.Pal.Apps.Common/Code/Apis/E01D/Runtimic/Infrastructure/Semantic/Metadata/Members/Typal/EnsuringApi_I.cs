using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface EnsuringApi_I<TContainer> : EnsuringApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
