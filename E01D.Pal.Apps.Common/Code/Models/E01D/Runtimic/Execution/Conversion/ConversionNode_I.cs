using Root.Code.Models.E01D.Runtimic.Execution.Bound;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
    public interface ConversionNode_I:BoundNodeBase_I
    {
        /// <summary>
        /// Gets or sets the conversion associated with this conversion entry.
        /// </summary>
        ILConversion Conversion { get; set; }

     

        
    }
}
