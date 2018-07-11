using System.Reflection.Emit;
using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public interface ConvertedGenericParameterTypeDefinition_I: ConvertedGenericParameterTypeDefinitionMask_I
    {
        new GenericTypeParameterBuilder Builder { get; set; }

        new GenericParameter Definition { get; set; }
        System.Type UnderlyingType { get; set; }
    }
}
