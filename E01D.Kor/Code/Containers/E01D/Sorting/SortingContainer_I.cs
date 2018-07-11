using Root.Code.Apis.E01D.Sorting;
using Root.Code.Models.E01D.Containment;

namespace Root.Code.Containers.E01D.Sorting
{
    public interface SortingContainer_I<TContainer> : Container_I
        where TContainer : SortingContainer_I<TContainer>
    {
        SortingContainerApi_I<TContainer> Api { get; }
    }
}
