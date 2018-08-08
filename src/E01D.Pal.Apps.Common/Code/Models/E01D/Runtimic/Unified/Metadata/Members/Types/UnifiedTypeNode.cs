using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types
{
    public abstract class UnifiedTypeNode:UnifiedNode
    {

		/// <summary>
		/// Gets or sets the cecil type reference associated with this unified type node.
		/// </summary>
	    public TypeReference CecilTypeReference { get; set; }

		/// <summary>
		/// Gets or sets whether this node is a primary node.  If it is not a primary node, it is a secondary node.
		/// </summary>
		public abstract bool IsPrimary { get; }
	}
}
