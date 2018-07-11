using Mono.Cecil.Cil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.IL
{
    public abstract class ExceptionBlock
    {
        public ExceptionHandler ExceptionHandler { get; set; }

        public int TryStartOffset { get; set; }

        public int TryEndOffset { get; set; }

        //public int HandlerStartOffset { get; set; }

        public int HandlerEndOffset { get; set; }

        public int FilterStartOffset { get; set; }

        public abstract ExceptionBlockKind Kind { get; }
    }
}
