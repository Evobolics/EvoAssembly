using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Generics
{
	public class GenericApi<TContainer> : ConversionApiNode<TContainer>, GenericApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
	    public BuildingApi_I<TContainer> Building { get; set; }

	    BuildingApiMask_I GenericApiMask_I.Building => Building;
	}
}
