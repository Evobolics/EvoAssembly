using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil.Cil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.IL
{
    public class LabelingApi<TContainer> : ConversionApiNode<TContainer>, LabelingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public Label GetLabel(Dictionary<int, ConvertedLabel> labelEntries, Instruction instructionDefinition)
        {
            Instruction instruction = (Instruction)instructionDefinition.Operand;

            int offset = instruction.Offset;

	        

            if (!labelEntries.TryGetValue(offset, out ConvertedLabel labelEntry))
            {
                throw new Exception("Lable is missing");
            }

            return labelEntry.Label;
        }
    }
}
