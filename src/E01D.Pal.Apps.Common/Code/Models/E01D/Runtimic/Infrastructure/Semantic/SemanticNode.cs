using System.Collections.Generic;
using Root.Code.Enums.E01D.Runtimic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic
{
    public class SemanticNode: SemanticNode_I
    {
        public Dictionary<string, SemanticNodeBaseMask_I> Dependencies { get; set; } =
            new Dictionary<string, SemanticNodeBaseMask_I>();
        public Dictionary<string, SemanticNodeBaseMask_I> Dependents { get; set; } =
            new Dictionary<string, SemanticNodeBaseMask_I>();

        /// <summary>
        /// Gets or sets the object network associated with the bound node.
        /// </summary>
        public object ObjectNetwork { get; set; }

        public InfrastructureRuntimicModelMask_I Model { get; set; }

        public RuntimicKind RuntimicKind { get; } = RuntimicKind.Bound;
    }
}
