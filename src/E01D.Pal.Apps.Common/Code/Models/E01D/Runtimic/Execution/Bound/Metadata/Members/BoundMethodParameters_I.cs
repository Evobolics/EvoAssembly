using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface BoundMethodParameters_I: BoundRoutineParametersMask_I
    {
        new List<SemanticRoutineParameterMask_I> All { get; set; }

        
    }
}
