using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members
{
    public class MemberApi<TContainer>: ExecutionApiNode<TContainer>, MemberApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

        #region Api(s)
        
		

        public TypeApi_I<TContainer> Types { get; set; }

	   

        TypeApiMask_I MemberApiMask_I.Types => Types;

        #endregion

        
    }
}
