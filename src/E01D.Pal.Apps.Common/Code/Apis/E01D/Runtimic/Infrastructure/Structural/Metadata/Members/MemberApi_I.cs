using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Members
{
    public interface MemberApi_I<TContainer> : MemberApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
