using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Creation
{
	public class GenericApi<TContainer> : ConversionApiNode<TContainer>, GenericApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
		
	}
}
