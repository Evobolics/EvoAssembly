namespace Root.Code.Apis.E01D.Sorting
{
	public interface SortingApiMask_I
	{
		BubbleApi_I Bubble { get; }

		InsertionApi_I Insertion { get; }

		QuickApiMask_I Quick { get; }
	}


}
