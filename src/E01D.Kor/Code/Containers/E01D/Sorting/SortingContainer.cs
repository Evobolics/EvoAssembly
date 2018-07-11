using Root.Code.Apis.E01D.Sorting;
using Root.Code.Attributes;
using Root.Code.Attributes.E01D;

namespace Root.Code.Containers.E01D.Sorting
{
	public class SortingContainer: SortingContainer_I<SortingContainer>
	{
		[ValueSetDynamically]
		public SortingContainerApi_I<SortingContainer> Api { get; set; }

		
	}
}
