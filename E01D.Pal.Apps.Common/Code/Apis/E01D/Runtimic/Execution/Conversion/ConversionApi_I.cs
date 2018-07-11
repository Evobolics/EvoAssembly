using System;
using System.IO;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion
{
    public interface ConversionApi_I<TContainer> : ConversionApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new ModelApi_I<TContainer> Models { get; set; }

        new  MetadataApi_I<TContainer> Metadata { get; set; }

        ILConversionResult ConvertType(Type type);

        ILConversionResult ConvertTypes(Type[] types);

        ILConversionResult ConvertAssembly(Stream stream);

        ILConversionResult ConvertAssembly(Stream[] streams);
    }
}
