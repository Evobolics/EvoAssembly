using Mono.Cecil.Cil;
using Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions
{
    public interface TypeScanningApiMask_I
    {
        
        

        void EnsureTypes(ILConversion conversion, Collection<Instruction> instructions);
    }
}
