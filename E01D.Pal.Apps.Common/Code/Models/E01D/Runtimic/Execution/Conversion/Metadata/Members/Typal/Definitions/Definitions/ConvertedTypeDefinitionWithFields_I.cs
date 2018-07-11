using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public interface ConvertedTypeDefinitionWithFields_I:BoundTypeDefinitionWithFieldsMask_I, ConvertedTypeDefinition_I
    {
        new ConvertedTypeDefinitionFields Fields { get; set; }
    }

    
}
