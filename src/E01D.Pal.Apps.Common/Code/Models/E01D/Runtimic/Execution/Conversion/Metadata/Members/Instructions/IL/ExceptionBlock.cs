using Root.Code.Libs.Mono.Cecil.Cil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.IL
{
    public abstract class ExceptionBlock
    {
        public ExceptionHandler ExceptionHandler { get; set; }

        /// <summary>
        /// Gets or sets the first instruction that is included in the try catch block
        /// </summary>
        public int TryStartOffset { get; set; }

        /// <summary>
        /// Gets the first instruction of the catch statement
        /// </summary>
        public int TryEndOffset { get; set; }

        //public int HandlerStartOffset { get; set; }

        /// <summary>
        /// Gets the first instruction that is outside of the catch statement
        /// </summary>
        public int HandlerEndOffset { get; set; }

        public int FilterStartOffset { get; set; }

        public abstract ExceptionBlockKind Kind { get; }
    }
}
