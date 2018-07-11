using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
	public interface CreationApi_I<TContainer>: CreationApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    
	}
}
