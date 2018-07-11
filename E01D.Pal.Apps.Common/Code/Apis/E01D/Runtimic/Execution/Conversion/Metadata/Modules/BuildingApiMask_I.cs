using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
    public interface BuildingApiMask_I
    {
        void BuildOut(ILConversion conversion, SemanticModuleMask_I boundModule);
    }
}
