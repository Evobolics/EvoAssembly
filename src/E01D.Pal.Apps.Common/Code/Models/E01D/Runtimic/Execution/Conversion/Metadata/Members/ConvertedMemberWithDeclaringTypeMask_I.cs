using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public interface ConvertedMemberWithDeclaringTypeMask_I: BoundMemberWithDeclaringTypeMask_I
    {
        new ConvertedTypeDefinitionMask_I DeclaringType { get; }
    }
}
