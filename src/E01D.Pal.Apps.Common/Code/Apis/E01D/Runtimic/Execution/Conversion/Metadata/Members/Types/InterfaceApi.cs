using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public class InterfaceApi<TContainer> : ConversionApiNode<TContainer>, InterfaceApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionInterfaces GetInterfaces(ILConversion conversion, TypeDefinition typeDefinition)
        {
            SemanticTypeDefinitionInterfaces all = new SemanticTypeDefinitionInterfaces();

            return all;
        }
    }
}
