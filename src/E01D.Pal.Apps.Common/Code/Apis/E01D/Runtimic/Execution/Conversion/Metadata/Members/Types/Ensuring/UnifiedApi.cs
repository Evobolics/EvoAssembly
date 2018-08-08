using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
	public class UnifiedApi<TContainer> : ConversionApiNode<TContainer>, UnifiedApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{

	}
}
