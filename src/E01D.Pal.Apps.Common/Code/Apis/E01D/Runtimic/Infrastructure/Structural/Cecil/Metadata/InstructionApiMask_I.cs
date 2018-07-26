using System.Reflection.Emit;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
    public interface InstructionApiMask_I
    {
        OpCode ConvertOpCode(Libs.Mono.Cecil.Cil.Code opCodeCode);
    }
}
