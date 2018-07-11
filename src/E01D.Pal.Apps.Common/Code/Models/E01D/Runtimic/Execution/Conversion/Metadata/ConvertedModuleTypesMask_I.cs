using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public interface ConvertedModuleTypesMask_I
    {
        Dictionary<string, ConvertedTypeMask_I> ConvertedByResolutionName { get; }
    }
}
