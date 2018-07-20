using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using MethodAttributes = System.Reflection.MethodAttributes;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
	public class BoundConstructorDefinition: BoundMember, BoundConstructorDefinitionMask_I
	{
		public MemberInfo UnderlyingMember => UnderlyingConstructor;
		public MethodReference MethodReference { get; set; }
		public SemanticRoutineParametersMask_I Parameters { get; set; }
		public ConstructorInfo UnderlyingConstructor { get; set; }
		public MethodAttributes ConstructorAttributes { get; set; }
		public BoundTypeDefinition_I DeclaringType { get; set; }
	}
}
