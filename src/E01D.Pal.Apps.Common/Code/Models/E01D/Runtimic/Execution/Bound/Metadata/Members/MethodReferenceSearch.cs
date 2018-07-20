using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
	public class MethodReferenceSearch
	{
		public ILConversion Conversion { get; set; }

		public GenericInstanceType GenericInstance { get; set; }

		public TypeDefinition GenericTypeDefinition { get; set; }

		public MethodInfo GenericInstanceMethodInfo { get; set; }

		public MethodInfo GenericTypeDefinitionMethodInfo { get; set; }

		public BoundMethodDefinitionMask_I GenericInstanceMethod { get; set; }

		public BoundMethodDefinitionMask_I BoundGenericTypeDefinitionMethod { get; set; }
		public MethodDefinition CurrentMethodReference { get; set; }
		public bool IsGenericTypeDefinitionConverted { get; set; }
		public MethodReference GenericTypeDefinitionMethod { get; set; }
	}
}
