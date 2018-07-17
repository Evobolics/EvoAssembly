using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public class ExtendingApi<TContainer> : ConversionApiNode<TContainer>, ExtendingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{

	}
}
