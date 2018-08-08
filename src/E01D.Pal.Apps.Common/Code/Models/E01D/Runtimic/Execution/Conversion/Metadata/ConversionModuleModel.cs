using System;
using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConversionModuleModel
    {
        public Dictionary<Guid, ConvertedModuleNode> ByVersionId { get; set; } =
            new Dictionary<Guid, ConvertedModuleNode>();

        
    }
}
