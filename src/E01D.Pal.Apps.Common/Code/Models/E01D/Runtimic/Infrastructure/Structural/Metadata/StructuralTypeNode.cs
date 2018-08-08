using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata
{
	public class StructuralTypeNode
	{
		public StructuralModuleNode Module { get; set; }

		public TypeReference CecilTypeReference { get; set; }
		public long Id { get; set; }
		public StructuralTypeNode PointerType { get; set; }
		public StructuralTypeNode ByRefType { get; set; }
		public bool IsPointerType { get; set; }

		public bool IsArrayType { get; set; }
		public StructuralTypeNode StemType { get; set; }
		public bool IsByReferenceType { get; set; }
		public bool IsDerived { get; set; }
		public int MetadataToken { get; set; }
		public bool IsGenericInstance { get; set; }
		public bool IsGenericParameter { get; set; }
		public string FullName { get; set; }
		public StructuralTypeNode[] GenericParameters { get; set; }
		public StructuralGenericInstanceTypeNode[] GenericInstances { get; set; }

		public StructuralTypeNode[] Arrays { get; set; }
		public uint Signature { get; set; }
		public int Rank { get; set; }
	}
}
