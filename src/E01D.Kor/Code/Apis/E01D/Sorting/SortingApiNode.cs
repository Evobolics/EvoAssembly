using Root.Code.Containers.E01D.Sorting;

namespace Root.Code.Apis.E01D.Sorting
{
	public class SortingApiNode<TContainer> : Api<TContainer>
		where TContainer: SortingContainer_I<TContainer>
    {

	}

    public class SortingApiNode<TContainer, TUnderlying> : Api<TContainer, TUnderlying>
        where TContainer : SortingContainer_I<TContainer>
    {

    }
}
