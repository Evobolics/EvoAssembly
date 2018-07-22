using Root.Code.Apis.E01D.Sorting;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Containers.E01D.Sorting;

namespace Root.Code.Apis.E01D.Runtimic
{
    [RequiresIOC]
    public interface RuntimicContainerApi_I<TContainer> : RuntimicContainerApiMask_I, SortingContainerApi_I<TContainer>
        where TContainer : SortingContainer_I<TContainer>, RuntimicContainer_I<TContainer>
    {
        new RuntimicApi_I<TContainer> Runtimic { get; set; }

        
    }
}
