using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConversionAssemblyModel
    {
        public Dictionary<string, ConvertedAssemblyNode> ByName { get; set; } =
            new Dictionary<string, ConvertedAssemblyNode>();

        public Dictionary<string, ConvertedAssemblyNode> BySourceName { get; set; } =
            new Dictionary<string, ConvertedAssemblyNode>();

        public Dictionary<long, ConvertedAssemblyNode> ById { get; set; } =
            new Dictionary<long, ConvertedAssemblyNode>();

        public Dictionary<long, ConvertedAssemblyNode> ByMetadataId { get; set; } =
            new Dictionary<long, ConvertedAssemblyNode>();
    }
}
