using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Creation
{
	public interface DefinitionApi_I<TContainer> : DefinitionApiMask_I
	    where TContainer : RuntimicContainer_I<TContainer>
    {
	}
}
