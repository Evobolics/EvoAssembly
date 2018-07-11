using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public interface ArrayApiMask_I
    {
        SemanticTypeDefinitionMask_I Ensure(ILConversion conversion, ConvertedModule_I convertedModule,
            TypeReference input, SemanticTypeDefinitionMask_I declaringType);
    }
}
