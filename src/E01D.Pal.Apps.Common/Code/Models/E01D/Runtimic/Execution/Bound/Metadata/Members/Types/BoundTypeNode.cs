using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	public class BoundTypeNode : ExecutionTypeNode_I
	{
		public bool IsPointerType { get; set; }

		public ExecutionTypeNode_I PointerType { get; set; }
		public ExecutionTypeNodeMask_I[] Arrays { get; set; }
		public ExecutionGenericInstanceTypeNode[] Generics { get; set; }
		public int Rank { get; set; }
		public ExecutionTypeNode_I StemType { get; set; }
		public bool IsDerived { get; set; }
		public int MetadataToken { get; set; }
		public StructuralTypeNode InputStructuralNode { get; set; }

		public BoundTypeDefinition Type { get; set; }

		ExecutionTypeDefinitionMask_I ExecutionTypeNodeMask_I.Type => Type;
		public ExecutionTypeNode_I ByReferenceType { get; set; }

		ExecutionTypeNode_I ExecutionTypeNodeMask_I.ByReferenceType => ByReferenceType;
		public int Id { get; set; }
		public bool IsByReferenceType { get; set; }
		public BoundAssemblyNode Assembly { get; set; }
		public BoundModuleNode Module { get; set; }
		public bool IsArrayType { get; set; }
	}
}
