using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members
{
    public interface MemberApi_I<TContainer>:MemberApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {
        

        new TypeApi_I<TContainer> Types { get; set; }
    }
}
