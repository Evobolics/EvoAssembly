using System.Reflection.Emit;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public interface ConvertedGenericParameterTypeDefinitionMask_I: BoundGenericParameterTypeDefinitionMask_I
    {
        GenericTypeParameterBuilder Builder { get;  }
    }
}
