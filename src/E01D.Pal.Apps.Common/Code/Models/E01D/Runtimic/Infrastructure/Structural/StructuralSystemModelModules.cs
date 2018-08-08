using System;
using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Structural
{
    public class StructuralSystemModelModules
    {
        public Dictionary<Guid, StructuralModuleNode> ByVersionId { get; set; } =
            new Dictionary<Guid, StructuralModuleNode>();
    }
}
