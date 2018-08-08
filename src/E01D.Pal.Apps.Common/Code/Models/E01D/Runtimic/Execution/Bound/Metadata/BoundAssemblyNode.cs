using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata
{
	public class BoundAssemblyNode
	{
		public long Id { get; set; }
		public StructuralAssemblyNode StructuralNode { get; set; }
		public long MetadataId { get; set; }
		public string FullName { get; set; }
		public BoundAssemblyMask_I BoundAssembly { get; set; }
	}
}
