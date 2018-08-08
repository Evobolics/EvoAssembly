using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public interface ConvertedRoutineParameters_I: ConvertedRoutineParametersMask_I
    {
        new List<SemanticRoutineParameterMask_I> All { get; set; }

        
    }
}
