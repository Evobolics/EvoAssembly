using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public interface InterfaceApiMask_I
    {
        SemanticTypeDefinitionInterfaces GetInterfaces(ILConversion conversion, TypeDefinition typeDefinition);
    }
}
