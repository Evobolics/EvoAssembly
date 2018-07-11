using Root.Code.Attributes;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Sorting;

namespace Root.Code.Apis.E01D.Sorting
{

	//public class SortingContainerApi : SortingContainerApi<SortingContainer_I<>>
	//{
		
	//}

	public class SortingContainerApi<TContainer>:Api<TContainer>, SortingContainerApi_I<TContainer>
        where TContainer:SortingContainer_I<TContainer>
    {
		[ValueSetDynamically]
		public SortingApi_I<TContainer> Sorting { get; set; }

		
	}
}
