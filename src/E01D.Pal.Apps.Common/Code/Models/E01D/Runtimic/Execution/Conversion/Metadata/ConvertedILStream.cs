using System.Reflection.Emit;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConvertedILStream
    {
        public ModuleBuilder ModuleBuilder { get; set; }
        public byte[] Buffer { get; set; }
        public int Position { get; set; }
        public int[] Fixups { get; set; }
        public int FixupCount { get; set; }
    }
}
