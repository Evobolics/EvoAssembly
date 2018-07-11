using Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Code.Containers.E01D.Sorting;

namespace Root.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion
{
    public interface ILConversionContainer_I:SortingContainer_I
	{
		new ILConversionContainerApi_I<ILConversionContainer_I> Api { get; }
    }
}
