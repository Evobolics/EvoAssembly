using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types
{
	public interface EnsuringApi_I<TContainer> : EnsuringApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
      
    }
}
