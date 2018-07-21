using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types
{
    public interface TypeApi_I<TContainer> : TypeApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    

        new EnsuringApi_I<TContainer> Ensuring { get; set; }

	   




    }
}
