using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
    public interface BuildingApiMask_I
    {

		ConvertedModule BuildOut(ILConversion conversion, UnifiedModuleNode moduleNode);
    }
}
