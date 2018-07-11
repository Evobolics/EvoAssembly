using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion
{
    public interface ConversionApiMask_I
    {
        MetadataApiMask_I Metadata { get; }

        ModelApiMask_I Models { get; }

        


    }
}
