using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedTypeDefinitionWithFields_I:BoundTypeDefinitionWithFieldsMask_I, ConvertedTypeDefinition_I
    {
        new ConvertedTypeDefinitionFields Fields { get; set; }
    }

    
}
