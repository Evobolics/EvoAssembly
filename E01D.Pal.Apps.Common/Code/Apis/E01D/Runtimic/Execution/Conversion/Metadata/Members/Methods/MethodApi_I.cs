using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods
{
    public interface MethodApi_I<TContainer>: MethodApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {
        new BuildingApi_I<TContainer> Building { get; set; }

        new GettingApi_I<TContainer> Getting { get; set; }

        new TypeParameterApi_I<TContainer> TypeParameters { get; set; }

        new TypeScanningApi_I<TContainer> TypeScanning { get; set; }

        
    }
}
