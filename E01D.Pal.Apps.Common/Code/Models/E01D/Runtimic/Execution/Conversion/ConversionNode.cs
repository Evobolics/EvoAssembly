using Root.Code.Enums.E01D;
using Root.Code.Enums.E01D.Runtimic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
    public abstract class ConversionNode: ConversionNode_I
    {
        /// <summary>
        /// Gets or sets the conversion associated with this conversion entry.
        /// </summary>
        public ILConversion Conversion { get; set; }

        ///// <summary>
        ///// Gets or sets all of the conversion entries that directly depend upon this entry.
        ///// </summary>
        //public Dictionary<string, SemanticNodeBaseMask_I> Dependencies { get; set; } = new Dictionary<string, SemanticNodeBaseMask_I>();

        ///// <summary>
        ///// Gets or sets all of the conversion entries that are directly dependent upon this entry.
        ///// </summary>
        //public Dictionary<string, SemanticNodeBaseMask_I> Dependents { get; set; } = new Dictionary<string, SemanticNodeBaseMask_I>();

        /// <summary>
        /// Gets or sets the object network associated with the node.
        /// </summary>
        public object ObjectNetwork { get; set; }

        /// <summary>
        /// Gets or sets the runtimic kind.
        /// </summary>
        public RuntimicKind RuntimicKind { get; } = RuntimicKind.Converted | RuntimicKind.Emitted | RuntimicKind.Bound;

        public PalKind PalKind { get; } = PalKind.App;
    }
}
