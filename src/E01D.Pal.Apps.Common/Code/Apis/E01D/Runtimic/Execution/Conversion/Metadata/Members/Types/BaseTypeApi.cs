using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
	public class BaseTypeApi<TContainer> : ConversionApiNode<TContainer>, BaseTypeApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public SemanticTypeMask_I GetBaseType(ILConversion conversion, SemanticModuleMask_I boundModule, TypeDefinition typeDefinition)
        {
            if (typeDefinition.BaseType == null) return null;

            var resolutionName = Types.Naming.GetResolutionName(typeDefinition.BaseType);

            var result = Models.Types.Get(conversion.Model, resolutionName);

            if (result != null) return result;
            
            return Execution.Types.Ensuring.Ensure(conversion.Model, typeDefinition.BaseType, null, null);
        }
    }
}
