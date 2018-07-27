using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedTypeWithRoutines_I
    {
        /// <summary>
        /// Gets or sets all of the routines that are associated with the converted type.
        /// </summary>
        List<ConvertedRoutineMask_I> Routines { get; set; }

        ConvertedRoutinesEmitState RoutinesEmitState { get; set; }
    
    }
}
