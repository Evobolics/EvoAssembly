using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Members.Types;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Members
{
    public class MemberApi<TContainer> : RuntimeApiNode<TContainer>, MemberApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

        public TypeApi_I<TContainer> Types { get; set; }

        TypeApiMask_I MemberApiMask_I.Types => Types;
    }
}
