using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public interface ConvertedMemberWithDeclaringType_I: ConvertedMemberWithDeclaringTypeMask_I
    {
        new ConvertedTypeDefinitionMask_I DeclaringType { get; set; }
    }
}
