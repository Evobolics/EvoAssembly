using System.Reflection.Emit;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedGenericParameterTypeDefinitionMask_I: BoundGenericParameterTypeDefinitionMask_I
    {
        GenericTypeParameterBuilder Builder { get;  }
    }
}
