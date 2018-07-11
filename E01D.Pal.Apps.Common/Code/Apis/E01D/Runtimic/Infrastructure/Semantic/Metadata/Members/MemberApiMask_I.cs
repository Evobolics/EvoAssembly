using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members
{
    public interface MemberApiMask_I
    {
        FieldApiMask_I Fields { get; }

        TypeApiMask_I Types { get;  }
        
    }
}
