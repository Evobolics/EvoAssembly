using Root.Code.Apis.E01D.Runtimic;
using Root.Code.Containers.E01D.Sorting;

namespace Root.Code.Containers.E01D.Runtimic
{
    public interface RuntimicContainer_I<TContainer>: SortingContainer_I<TContainer>
        where TContainer : SortingContainer_I<TContainer>, RuntimicContainer_I<TContainer>
    {
        new RuntimicContainerApi_I<TContainer> Api { get; }

    }
}
