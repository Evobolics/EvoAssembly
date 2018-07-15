using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion
{
    public interface ConversionApi_I<TContainer> : ConversionApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    new InternalApi_I<TContainer> Internal { get; set; }

		new ModelApi_I<TContainer> Models { get; set; }

        new  MetadataApi_I<TContainer> Metadata { get; set; }

       
	    
    }
}
