using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
	public interface BoundMemberWithDeclaringType_I: BoundMemberWithDeclaringTypeMask_I
	{
		new BoundTypeDefinitionMask_I DeclaringType { get; set; }
	}
}
