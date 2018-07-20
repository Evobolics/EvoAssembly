using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
	public class ConstructorBuildInfo
	{
		public ConstructorInfo GenericTypeDefinitionConstructorInfo { get; set; }
		public BoundConstructorDefinitionMask_I GenericTypeDefinitionBoundConstructor { get; set; }
		public ConstructorInfo GenericTypeInstanceConstructorInfo { get; set; }
		public MethodReference GenericTypeInstanceMethodReference { get; set; }
	}
}
