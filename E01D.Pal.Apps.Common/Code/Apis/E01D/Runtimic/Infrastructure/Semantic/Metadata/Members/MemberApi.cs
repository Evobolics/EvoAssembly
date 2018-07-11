using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members
{
    public class MemberApi<TContainer> : SemanticApiNode<TContainer>, MemberApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public FieldApi_I<TContainer> Fields { get; set; }
        
        FieldApiMask_I MemberApiMask_I.Fields => this.Fields;

        public new TypeApi_I<TContainer> Types { get; set; }

        TypeApiMask_I MemberApiMask_I.Types => Types;
    }
}
