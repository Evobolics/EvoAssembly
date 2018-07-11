using System.Collections.Generic;
using Mono.Cecil.Cil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.IL
{
    public class TryCatchBlock: ExceptionBlock
    {
        public override ExceptionBlockKind Kind => ExceptionBlockKind.Catch;

        public Dictionary<int, List<ExceptionHandler>> HandlerEntries { get; set; } = new Dictionary<int, List<ExceptionHandler>>();
    }
}
