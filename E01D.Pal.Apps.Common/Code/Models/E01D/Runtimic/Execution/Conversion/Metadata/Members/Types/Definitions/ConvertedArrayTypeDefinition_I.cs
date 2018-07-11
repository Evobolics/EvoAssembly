using Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedArrayTypeDefinition_I: ConvertedArrayTypeDefinitionMask_I,
		ConvertedArrayTypeDefinitionClassifier_I,
		ConvertedTypeDefinitionWithMethods_I,
	    ConvertedTypeDefinitionWithConstructors_I

	{
        new SemanticTypeDefinitionMask_I ElementType { get; set; }
    }
}
