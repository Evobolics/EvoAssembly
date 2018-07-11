using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
	public class LocalApi<TContainer> : ConversionApiNode<TContainer>, LocalApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	}
}
