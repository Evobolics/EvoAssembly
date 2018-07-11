using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines.Finding
{
    public interface ParameterMatchingApiMask_I
    {
        bool VerifyParameters(ILConversion conversion, MethodReference currentMethod, MethodReference targetMethod);
    }
}
