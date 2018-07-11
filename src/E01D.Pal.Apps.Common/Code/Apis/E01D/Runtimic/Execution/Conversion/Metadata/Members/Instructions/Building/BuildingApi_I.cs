using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.IL;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building
{
    public interface BuildingApi_I<TContainer> : BuildingApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new ILApi_I<TContainer> IL { get; set; }
    }
}
