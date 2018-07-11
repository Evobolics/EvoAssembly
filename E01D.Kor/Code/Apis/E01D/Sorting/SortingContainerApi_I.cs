using Root.Code.Containers.E01D.Sorting;

namespace Root.Code.Apis.E01D.Sorting
{
	public interface SortingContainerApi_I<TContainer>: Api_I<TContainer>
        where TContainer : SortingContainer_I<TContainer>
    {
        SortingApi_I<TContainer> Sorting { get; set; }
	}
}
