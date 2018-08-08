using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
    public interface BaseTypeApiMask_I
    {
        SemanticTypeMask_I GetBaseType(RuntimicSystemModel semanticModel, TypeDefinition typeDefinition);
    }
}
