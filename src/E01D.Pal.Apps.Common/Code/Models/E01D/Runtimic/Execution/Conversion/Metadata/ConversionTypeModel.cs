using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConversionTypeModel
    {
        public Dictionary<long, ConversionTypeNode> ById { get; set; } = new Dictionary<long, ConversionTypeNode>();

        public Dictionary<long, ConversionTypeNode> ByMetadataId { get; set; } = new Dictionary<long, ConversionTypeNode>();

    }
}
