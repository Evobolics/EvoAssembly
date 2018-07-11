using Root.Code.Apis.E01D.Runtimic;
using Root.Code.Apis.E01D.Sorting;
using Root.Code.Containers.E01D.Sorting;

namespace Root.Code.Containers.E01D.Runtimic
{
    public class RuntimicContainer: RuntimicContainer_I<RuntimicContainer>
    {
        public RuntimicContainerApi_I<RuntimicContainer> Api { get; set; }

        SortingContainerApi_I<RuntimicContainer> SortingContainer_I<RuntimicContainer>.Api => Api;
    }
}
