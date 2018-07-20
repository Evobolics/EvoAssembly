using Root.Code.Libs.Mono.Cecil.Cil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.IL
{
    public class ExceptionBlockEventEntry
    {
        public ExceptionBlockEventKind Kind { get; set; }

        public ExceptionBlock ExceptionBlock { get; set; }


        public int Offset { get; set; }
        public ExceptionHandler ExceptionHandler { get; set; }
    }
}
