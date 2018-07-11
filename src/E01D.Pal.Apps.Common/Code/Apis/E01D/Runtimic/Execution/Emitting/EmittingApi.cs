using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Emitting
{
    /// <summary>
    /// Provides runtime execution emitting services.
    /// </summary>
    public class EmittingApi<TContainer> : ExecutionApiNode<TContainer>, EmittingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        /// <summary>
        /// Gets or sets the api used to convert assemblies from non-collectible to collectible.
        /// </summary>
        public ConversionApi_I<TContainer> Conversion { get; set; }

        ConversionApiMask_I EmittingApiMask_I.Conversion => Conversion;
    }
}
