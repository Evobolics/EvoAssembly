using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members
{
    public interface SemanticRoutineMask_I:SemanticMemberMask_I
    {
	    MethodReference MethodReference { get; }

        SemanticRoutineParametersMask_I Parameters { get; }
    }
}
