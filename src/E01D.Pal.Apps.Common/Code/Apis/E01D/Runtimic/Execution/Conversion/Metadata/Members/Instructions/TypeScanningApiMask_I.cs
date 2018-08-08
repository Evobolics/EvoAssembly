using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Cil;
using Root.Code.Libs.Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions
{
    public interface TypeScanningApiMask_I
    {
        
        

        void EnsureTypes(ILConversion conversion, Collection<Instruction> instructions);

	    void EnsureTypes(ILConversion conversion, ConvertedTypeDefinition_I converted, MethodDefinition callingMethodDefinition, Collection<Instruction> instructions);

    }
}
