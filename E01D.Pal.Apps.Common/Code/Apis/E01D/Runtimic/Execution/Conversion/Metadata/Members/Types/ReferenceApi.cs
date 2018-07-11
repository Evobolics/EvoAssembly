using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
	public class ReferenceApi<TContainer> : ConversionApiNode<TContainer>, ReferenceApi_I<TContainer>
	    where TContainer : RuntimicContainer_I<TContainer>
    {
	}
}
