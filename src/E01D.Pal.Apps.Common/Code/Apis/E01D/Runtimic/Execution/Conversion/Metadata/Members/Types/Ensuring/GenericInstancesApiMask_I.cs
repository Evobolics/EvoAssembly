using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public interface GenericInstancesApiMask_I
    {
        SemanticTypeDefinitionMask_I Ensure(ILConversion conversion,TypeReference input, SemanticTypeDefinitionMask_I declaringType);
    }
}
