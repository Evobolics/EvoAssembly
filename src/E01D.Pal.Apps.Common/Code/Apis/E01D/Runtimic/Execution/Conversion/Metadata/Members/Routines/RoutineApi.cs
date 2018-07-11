using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines.Finding;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines
{
    public class RoutineApi<TContainer> : ConversionApiNode<TContainer>,RoutineApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I RoutineApiMask_I.Building => Building;

        public FindingApi_I<TContainer> Finding { get; set; }

        FindingApiMask_I RoutineApiMask_I.Finding => Finding;
    }
}
