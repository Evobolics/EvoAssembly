using System.Collections.Generic;
using Root.Code.Enums.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Emitting
{
    public class EmittedNode: EmittedNode_I
    {
        public Dictionary<string, SemanticNodeBaseMask_I> Dependencies { get; set; } =
            new Dictionary<string, SemanticNodeBaseMask_I>();
        public Dictionary<string, SemanticNodeBaseMask_I> Dependents { get; set; } =
            new Dictionary<string, SemanticNodeBaseMask_I>();

        public object ObjectNetwork { get; set; }

        public RuntimicKind RuntimicKind { get; } = RuntimicKind.Emitted | RuntimicKind.Bound;
    }
}
