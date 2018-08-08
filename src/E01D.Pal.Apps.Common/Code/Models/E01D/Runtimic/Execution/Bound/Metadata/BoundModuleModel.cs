using System;
using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata
{
    public class BoundModuleModel
    {
        public Dictionary<Guid, BoundModuleNode> ByVersionId { get; set; } =
            new Dictionary<Guid, BoundModuleNode>();
    }
}
