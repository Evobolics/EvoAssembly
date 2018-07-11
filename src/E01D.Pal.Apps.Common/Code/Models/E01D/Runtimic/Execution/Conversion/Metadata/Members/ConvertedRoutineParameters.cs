using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public class ConvertedRoutineParameters: ConvertedRoutineParameters_I
    {
        public List<SemanticRoutineParameterMask_I> All { get; set; } = new List<SemanticRoutineParameterMask_I>();

        public Dictionary<string, SemanticRoutineParameterMask_I> ByName { get; set; } =
            new Dictionary<string, SemanticRoutineParameterMask_I>();
    }
}
