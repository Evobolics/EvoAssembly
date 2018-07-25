using System.Reflection.Emit;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedGenericParameterTypeDefinition_I: ConvertedTypeParameterDefinitionMask_I, ExecutionTypeParameterDefinition_I
	{
        new GenericTypeParameterBuilder Builder { get; set; }

        
	}
}
