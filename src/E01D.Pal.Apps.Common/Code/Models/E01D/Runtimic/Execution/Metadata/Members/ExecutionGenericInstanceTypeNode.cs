using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{
	public class ExecutionGenericInstanceTypeNode: ExecutionTypeNode, ExecutionGenericInstanceTypeNodeMask_I
	{
		public ExecutionTypeNode_I[] Arguments { get; set; }
		public ConvertedAssemblyNode Assembly { get; set; }
		public int Id { get; set; }
		public StructuralTypeNode InputStructuralNode { get; set; }
		public bool IsDerived { get; set; }
		public ConvertedModuleNode Module { get; set; }
	}
}
