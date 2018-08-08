using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public class TypeScanningApi<TContainer> : ConversionApiNode<TContainer>, TypeScanningApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        

        public SemanticTypeDefinitionMask_I EnsureType(ILConversion conversion, TypeReference typeReference)
        {
            if (typeReference is GenericParameter)
            {
                return null;
            }

            //var typeScanReference = Cecil.ResolveForTypeScan(null, typeReference);

	        return Execution.Types.Ensuring.Ensure(conversion, typeReference, null, null);
        }
    }

    
}
