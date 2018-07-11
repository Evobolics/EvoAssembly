using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building
{
    public interface BuildingApiMask_I
    {
	    DynamicallyCreatedApiMask_I Emitted { get; }

	    RuntimeCreatedApiMask_I RuntimeCreated { get; }

	    MethodInfo MakeArrayMethod(ILConversion conversion, ConvertedTypeDefinition_I callingType, BoundTypeDefinitionMask_I declaringType, MethodReference methodReference);
	    
    }
}
