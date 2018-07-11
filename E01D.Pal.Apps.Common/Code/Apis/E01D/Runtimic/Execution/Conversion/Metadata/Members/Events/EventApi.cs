using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Events
{
	public class EventApi<TContainer> : ConversionApiNode<TContainer>, EventApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I EventApiMask_I.Building => Building;

        public TypeScanningApi_I<TContainer> TypeScanning { get; set; }

        TypeScanningApiMask_I EventApiMask_I.TypeScanning => TypeScanning;
    }
}
