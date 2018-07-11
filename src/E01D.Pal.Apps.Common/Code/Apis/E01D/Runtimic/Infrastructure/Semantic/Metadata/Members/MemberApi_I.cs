using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members
{
    public interface MemberApi_I<TContainer> : MemberApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new FieldApi_I<TContainer> Fields { get; set; }

        new TypeApi_I<TContainer> Types { get; set; }
    }
}
