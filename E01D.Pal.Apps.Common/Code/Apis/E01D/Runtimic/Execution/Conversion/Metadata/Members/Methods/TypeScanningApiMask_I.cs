using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods
{
    public interface TypeScanningApiMask_I
    {
        
        void EnsureTypes(ILConversion conversion, SemanticTypeMask_I boundTypeMask);

        void EnsureTypes(ILConversion conversion, Mono.Cecil.MethodDefinition method, TypeReference genericArgumentSource);

        
    }
}
