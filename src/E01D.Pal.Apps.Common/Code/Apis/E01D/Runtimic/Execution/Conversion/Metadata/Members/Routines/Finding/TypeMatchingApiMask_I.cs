using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines.Finding
{
    public interface TypeMatchingApiMask_I
    {
        bool VerifyTypeMatch(ILConversion conversion, TypeReference methodDefType, TypeReference methodSpecType,
            GenericArgumentEntryMap map);
    }
}
