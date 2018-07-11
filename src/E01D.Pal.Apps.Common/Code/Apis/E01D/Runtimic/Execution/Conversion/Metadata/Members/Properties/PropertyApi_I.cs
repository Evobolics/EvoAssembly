using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Properties
{
    public interface PropertyApi_I<TContainer> : PropertyApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new BuildingApi_I<TContainer> Building { get; set; }

        new TypeScanningApi_I<TContainer> TypeScanning { get; set; }
    }
}
