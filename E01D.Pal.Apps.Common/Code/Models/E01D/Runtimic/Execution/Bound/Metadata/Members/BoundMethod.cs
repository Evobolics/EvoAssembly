using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public class BoundMethod: BoundMember, BoundMethodDefinition_I
    {
        

        public BoundTypeDefinition_I DeclaringType { get; set; }
		public System.Reflection.MethodAttributes MethodAttributes { get; set; }

	    public MethodReference MethodReference { get; set; }
		public BoundTypeDefinitionMask_I ReturnType { get; set; }
        public BoundMethodParameters_I Parameters { get; set; } = new BoundMethodParameters();
        
        public BoundGenericParameterTypeDefinitions_I TypeParameters { get; set; } = new BoundGenericParameterTypeDefinitions();
        public MemberInfo UnderlyingMember => UnderlyingMethod;
        public MethodInfo UnderlyingMethod { get; set; }

	    SemanticRoutineParametersMask_I SemanticRoutineMask_I.Parameters => Parameters;

	    BoundRoutineParametersMask_I BoundRoutineDefinitionMask_I.Parameters => Parameters;

		BoundGenericParameterTypeDefinitionsMask_I BoundMemberWithTypeParametersMask_I.TypeParameters => TypeParameters;

	    SemanticGenericParameterTypeDefinitionsMask_I SemanticMethodMask_I.TypeParameters => TypeParameters;
    }
}
