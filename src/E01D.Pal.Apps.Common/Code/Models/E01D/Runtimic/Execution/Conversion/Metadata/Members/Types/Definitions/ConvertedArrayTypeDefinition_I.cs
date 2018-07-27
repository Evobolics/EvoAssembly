using Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedArrayTypeDefinition_I: ExecutionArrayTypeDefinition_I,
        ConvertedArrayTypeDefinitionMask_I,
		ConvertedArrayTypeDefinitionClassifier_I,
	    ConvertedTypeWithConstructors_I

	{
        
    }
}
