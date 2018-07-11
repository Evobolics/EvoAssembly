using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public class TypeScanningApi<TContainer> : ConversionApiNode<TContainer>, TypeScanningApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        

        public void EnsureType(ILConversion conversion, TypeReference typeReference)
        {
            if (typeReference is Mono.Cecil.GenericParameter)
            {
                return;
            }

            var typeScanReference = Cecil.ResolveForTypeScan(null, typeReference);

	        //Types.Ensuring.Ensure(conversion, typeScanReference, null);
        }
    }

    
}
