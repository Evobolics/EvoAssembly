using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Creation
{
	public interface ReferenceApi_I<TContainer>: ReferenceApiMask_I
	    where TContainer : RuntimicContainer_I<TContainer>
    {
	}
}
