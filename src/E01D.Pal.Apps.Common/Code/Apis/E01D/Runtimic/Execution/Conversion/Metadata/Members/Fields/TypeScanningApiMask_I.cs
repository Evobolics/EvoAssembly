using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields
{
    public interface TypeScanningApiMask_I
    {
        void EnsureTypes(ILConversion conversion, SemanticTypeMask_I input);

        void EnsureTypes(ILConversion conversion, FieldDefinition field, TypeReference genericArgumentSource);
    }
}
