using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata
{
	public class BoundModuleNode
	{
		public BoundAssemblyNode AssemblyNode { get; set; }

		public BoundModule BoundModule { get; set; }

		public StructuralModuleNode InputStructuralDefinition { get; set; }

		public Dictionary<int, BoundTypeTable> Tables { get; set; } =
			new Dictionary<int, BoundTypeTable>();
	}
}
