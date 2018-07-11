using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConvertedModuleTypes: BoundModuleTypes, ConvertedModuleTypes_I
    {
        public Dictionary<string, ConvertedTypeMask_I> ConvertedByResolutionName { get; set; } =
            new Dictionary<string, ConvertedTypeMask_I>();
    }
}
