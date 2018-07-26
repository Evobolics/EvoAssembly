using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public class ConvertedRoutineLocalVariable
    {
        

        public List<object> CustomModifiers { get; set; }

        /// <summary>
        /// Gets or sets the underlying type.
        /// </summary>
        public Type UnderlyingType { get; set; }

        /// <summary>
        /// Gets or sets whether the local variable is pinned.
        /// </summary>
        public bool IsPinned { get; set; }
    }
}
