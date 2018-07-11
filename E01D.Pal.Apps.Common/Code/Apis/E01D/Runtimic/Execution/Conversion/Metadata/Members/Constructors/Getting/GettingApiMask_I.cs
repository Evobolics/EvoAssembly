using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Getting
{
    public interface GettingApiMask_I
    {
	    SemanticConstructorMask_I GetConstructor(ILConversion conversion, ConvertedConstructorCallInformation callInformation);

	    SemanticConstructorMask_I GetConstructor(ILConversion conversion, BoundTypeDefinitionWithConstructorsMask_I declaringType, MethodReference methodReference);


    }
}
