using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types.Secondary
{
    public class UnifiedPointerTypeNode: UnifiedTypeNode, UnifiedSubTypeNode_I
    {
		/// <summary>
		/// Gets the super type that this sub type is based upon.
		/// </summary>
        public UnifiedTypeNode SuperType { get; set; }

		/// <summary>
		/// Gets or sets the current execution type that is associated with this pointer type node.  This is a type that is either
		/// bound or currently converted.
		/// </summary>
        public ExecutionType_I ExecutionType { get; set; }

		public override bool IsPrimary => false;
	}
}
