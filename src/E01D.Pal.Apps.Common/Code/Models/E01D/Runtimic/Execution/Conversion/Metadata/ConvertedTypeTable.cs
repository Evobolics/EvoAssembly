using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConvertedTypeTable
    {
        public Dictionary<uint, ConversionTypeNode> ByRow { get; set; } = new Dictionary<uint, ConversionTypeNode>();


    }
}
