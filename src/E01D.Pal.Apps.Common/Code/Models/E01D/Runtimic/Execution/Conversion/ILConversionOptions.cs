using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
    public class ILConversionOptions
    {
        public AssemblyBuilderAccess BuilderAccess { get; set; } = AssemblyBuilderAccess.RunAndCollect;

        public bool UseILGenerator { get; set; } = true;
    }
}
