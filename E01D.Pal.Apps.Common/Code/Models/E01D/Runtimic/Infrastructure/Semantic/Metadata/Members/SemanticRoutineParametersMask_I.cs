using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members
{
    public interface SemanticRoutineParametersMask_I
    {
        List<SemanticRoutineParameterMask_I> All { get; }

        Dictionary<string, SemanticRoutineParameterMask_I> ByName { get; }
    }
}
