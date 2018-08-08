using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
    public interface CreationApiMask_I
    {


        

        ConvertedModule Create(ILConversion conversion, ConvertedModuleNode moduleNode);
    }
}
