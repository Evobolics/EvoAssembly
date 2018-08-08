using System.Reflection.Emit;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
    public class ILConversionOptions
    {
        public AssemblyBuilderAccess BuilderAccess { get; set; } = AssemblyBuilderAccess.RunAndCollect;
        
        public bool UseILGenerator { get; set; } = false;
    }
}
