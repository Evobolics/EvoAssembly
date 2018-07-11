using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedTypeDefinitionWithTypeParametersMask_I: BoundTypeDefinitionWithTypeParametersMask_I
    {
        new ConvertedGenericParameterTypeDefinitionsMask_I TypeParameters { get; }
    }
}
