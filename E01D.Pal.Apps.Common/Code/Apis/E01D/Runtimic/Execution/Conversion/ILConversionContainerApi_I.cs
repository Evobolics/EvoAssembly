using Root.Code.Apis.E01D.Sorting;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion
{
	public interface ILConversionContainerApi_I<TContainer>:SortingContainerApi_I
	    where TContainer : RuntimicContainer_I
    {
	    ConversionApi_I<TContainer> ILConversion { get; set; }
    }
}
