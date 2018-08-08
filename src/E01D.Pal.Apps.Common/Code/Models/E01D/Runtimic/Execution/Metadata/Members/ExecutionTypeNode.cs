using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{
	public class ExecutionTypeNode: ExecutionTypeNode_I
	{
		public ExecutionTypeDefinitionMask_I Type { get; set; }

		public ExecutionTypeNode_I PointerType { get; set; }

		public ExecutionTypeNode_I ByReferenceType { get; set; }

		ExecutionTypeNode_I ExecutionTypeNodeMask_I.ByReferenceType => ByReferenceType;

		public ExecutionTypeNodeMask_I[] Arrays { get; set; }
		public ExecutionGenericInstanceTypeNode[] Generics { get; set; }

		ExecutionTypeNode_I ExecutionTypeNodeMask_I.PointerType => PointerType;

		public int Rank { get; set; }
	}
}
