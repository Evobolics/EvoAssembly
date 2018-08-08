using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata
{
    public class BoundAssemblyModel
    {
        public Dictionary<string, BoundAssemblyNode> ByName { get; set; } =
            new Dictionary<string, BoundAssemblyNode>();

        public Dictionary<long, BoundAssemblyNode> ById { get; set; } =
            new Dictionary<long, BoundAssemblyNode>();

        public Dictionary<long, BoundAssemblyNode> ByMetadataId { get; set; } =
            new Dictionary<long, BoundAssemblyNode>();
    }
}
