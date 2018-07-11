using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface BoundMemberWithDeclaringTypeMask_I: SemanticMemberWithDeclaringTypeMask_I
    {
        new BoundTypeDefinitionMask_I DeclaringType { get; }


    }
}
