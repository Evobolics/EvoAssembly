using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
	public class ConversionTypeNode: ExecutionTypeNode_I
	{
		public long Id { get; set; }
		public StructuralTypeNode InputStructuralNode { get; set; }
		public bool IsDerived { get; set; }
		public ExecutionTypeNode_I StemType { get; set; }
		public ExecutionTypeNode_I PointerType { get; set; }
		public ExecutionTypeNodeMask_I[] Arrays { get; set; }
		public ExecutionGenericInstanceTypeNode[] Generics { get; set; }
		public int Rank { get; set; }
		public bool IsPointerType { get; set; }
		public int MetadataToken { get; set; }
		public ExecutionTypeNode_I ByReferenceType { get; set; }

		ExecutionTypeNode_I ExecutionTypeNodeMask_I.ByReferenceType => ByReferenceType;

		public bool IsByReferenceType { get; set; }
		public ConvertedModuleNode Module { get; set; }
		public ConvertedAssemblyNode Assembly { get; set; }

		public ConvertedTypeDefinition_I Type { get;set; }

		ExecutionTypeDefinitionMask_I ExecutionTypeNodeMask_I.Type => Type;
		public bool IsArrayType { get; set; }
	}
}
