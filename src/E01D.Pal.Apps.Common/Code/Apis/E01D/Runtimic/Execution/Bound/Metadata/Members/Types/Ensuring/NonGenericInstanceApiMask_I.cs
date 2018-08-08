using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
    public interface NonGenericInstanceApiMask_I
    {
        SemanticTypeDefinitionMask_I Ensure(RuntimicSystemModel semanticModel, TypeReference input, BoundTypeDefinitionMask_I boundDeclaringType, System.Type underlyingType);
    }
}
