using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithILGenerator
{
    public interface WithILGeneratorApiMask_I
    {
        bool GenerateIL(ILConversion conversion, ConvertedTypeDefinition_I convertedType);

        
    }
}
