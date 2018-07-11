using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines.Finding;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines
{
    public interface RoutineApiMask_I
    {
        BuildingApiMask_I Building { get; }
        FindingApiMask_I Finding { get; }
    }
}
