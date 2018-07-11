using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface BoundRoutineDefinitionMask_I: BoundMemberDefinitionMask_I, SemanticRoutineMask_I
    {
        new BoundRoutineParametersMask_I Parameters { get; }
    }
}
