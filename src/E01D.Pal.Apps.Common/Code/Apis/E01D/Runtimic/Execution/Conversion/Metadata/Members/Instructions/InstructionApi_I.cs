using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions
{
    public interface InstructionApi_I<TContainer>: InstructionApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {
        new BuildingApi_I<TContainer> Building { get; set; }

        new TypeScanningApi_I<TContainer> TypeScanning { get; set; }
    }
}
