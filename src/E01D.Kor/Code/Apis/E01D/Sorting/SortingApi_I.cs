using Root.Code.Containers.E01D.Sorting;

namespace Root.Code.Apis.E01D.Sorting
{
    public interface SortingApi_I<TContainer>: SortingApiMask_I
        where TContainer: SortingContainer_I<TContainer>
    {
    }
}
