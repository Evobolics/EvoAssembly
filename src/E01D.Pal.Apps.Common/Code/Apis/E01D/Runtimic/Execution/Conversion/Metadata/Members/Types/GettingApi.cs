using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
	public class GettingApi<TContainer> : ConversionApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		

	    public ConvertedType_I Get(ILConversion conversion, SemanticModuleMask_I module, TypeReference input)
	    {
	        string resolutionName = Types.Naming.GetResolutionName(input);

	        if (!module.Types.ByResolutionName.TryGetValue(resolutionName, out SemanticTypeMask_I typeEntry))
	        {
	            return null;
	        }

	        ConvertedType_I converetedType = typeEntry as ConvertedType_I;

	        if (converetedType == null) throw new System.Exception("Expected convereted type.");

            return converetedType;
	    }

        
    }
}
