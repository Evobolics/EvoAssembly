using Root.Code.Apis.E01D.Sorting;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic
{
    

    public class RuntimicContainerApi<TContainer> : Api<TContainer>, RuntimicContainerApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>

    {
        
        
        public RuntimicApi_I<TContainer> Runtimic { get; set; }

        public SortingApi_I<TContainer> Sorting { get; set; }

        RuntimicApiMask_I RuntimicContainerApiMask_I.Runtimic => Runtimic;
    }
}
