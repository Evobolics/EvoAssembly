using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
    public class ILConversionConfiguration
    {
        /// <summary>
        /// Gets or sets the type of assembly that should be created when the assemblies are emitted.  The default
        /// value is RunAndCollect.
        /// </summary>
        public AssemblyBuilderAccess BuilderAccess { get; set; } = AssemblyBuilderAccess.RunAndCollect;

        public bool DoNotConvertCorlib { get; set; } = true;
        public bool IsConvertingTypeSet { get; set; }
        public Dictionary<string, Assembly> ConvertedAssemblies { get; set; } = new Dictionary<string, Assembly>();
    }
}
