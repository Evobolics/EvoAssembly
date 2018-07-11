using System.Collections.Generic;
using System.Reflection.Emit;
using Mono.Cecil.Cil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.IL
{
    public interface LabelingApiMask_I
    {
        Label GetLabel(Dictionary<int, ConvertedLabel> labelEntries, Instruction instructionDefinition);
    }
}
