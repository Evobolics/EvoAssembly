using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public interface ConvertedTypeDefinitionWithMethods_I : BoundTypeDefinitionWithMethodsMask_I, ConvertedTypeDefinition_I
    {
        new ConvertedTypeDefinitionMethods Methods { get; set; }
    }
}
