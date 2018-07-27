using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedTypeWithMethods_I : BoundTypeDefinitionWithMethodsMask_I, ConvertedTypeDefinition_I, ConvertedTypeWithRoutines_I
    {
        new ConvertedTypeDefinitionMethods Methods { get; set; }
    }
}
