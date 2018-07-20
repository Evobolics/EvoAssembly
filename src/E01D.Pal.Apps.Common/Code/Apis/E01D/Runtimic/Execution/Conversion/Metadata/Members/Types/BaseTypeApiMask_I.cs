using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public interface BaseTypeApiMask_I
    {
        SemanticTypeMask_I GetBaseType(ILConversion conversion, SemanticModuleMask_I boundModule, TypeDefinition typeDefinition);
    }
}
