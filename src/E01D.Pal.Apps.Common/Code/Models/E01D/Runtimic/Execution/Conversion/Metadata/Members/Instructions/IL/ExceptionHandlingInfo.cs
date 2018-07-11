using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.IL
{
    public class ExceptionHandlingInfo
    {
        public List<ExceptionBlock> ExceptionBlocks = new List<ExceptionBlock>();

        public List<TryCatchBlock> TryCatchEntries = new List<TryCatchBlock>();

        public Dictionary<int, List<ExceptionBlockEventEntry>> Events { get; set; } =
            new Dictionary<int, List<ExceptionBlockEventEntry>>();
    }
}
