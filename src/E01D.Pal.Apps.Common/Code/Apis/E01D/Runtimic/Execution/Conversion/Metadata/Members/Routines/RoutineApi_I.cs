using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines.Finding;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines
{
    public interface RoutineApi_I<TContainer> : RoutineApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new BuildingApi_I<TContainer> Building { get; set; }

        new FindingApi_I<TContainer> Finding { get; set; }
    }
}
