using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public interface ConvertedMemberWithTypeParametersMask_I: BoundMemberWithTypeParametersMask_I
    {
        new ConvertedGenericParameterTypeDefinitionsMask_I TypeParameters { get; }
    }
}
