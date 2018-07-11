using Root.Code.Apis.E01D.Sorting;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion
{


    public class ILConversionContainerApi<TContainer> : Api<TContainer>, ILConversionContainerApi_I<TContainer>
        where TContainer : RuntimicContainer_I
    {
        #region Api(s)

        //public ConversionApi_I<TContainer> ILConversion { get; set; }

        //public SortingApi_I<TContainer> Sorting { get; set; }

        //ConversionApiMask_I ILConversionContainerApi_I.ILConversion => ILConversion;

        //SortingApiMask_I SortingContainerApi_I.Sorting => Sorting;

        #endregion
        public ConversionApi_I<TContainer> ILConversion { get; set; }

        public SortingApi_I<TContainer> Sorting { get; set; }
    }
}
