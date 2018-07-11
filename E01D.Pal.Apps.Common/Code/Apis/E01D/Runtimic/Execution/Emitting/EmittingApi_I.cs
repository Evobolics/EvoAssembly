using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Emitting
{
    public interface EmittingApi_I<TContainer>: EmittingApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {
        new ConversionApi_I<TContainer> Conversion { get; set; }
    }
}
