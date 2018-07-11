using System.Reflection.Emit;
using Mono.Cecil.Cil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.IL;
using ExceptionHandler = Mono.Cecil.Cil.ExceptionHandler;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.IL
{
    public interface ExceptionHandlingApiMask_I
    {
        ExceptionHandlingInfo Preprocess(ILConversion conversion, MethodBody methodDefinitionBody);

        void AddEvent(ILConversion conversion, ExceptionBlockEventKind eventKind,
            ExceptionHandlingInfo handlingInfo, int offset, ExceptionBlock exceptionBlock,
            ExceptionHandler exceptionHandler);

        void AddEvent(ILConversion conversion, ExceptionBlockEventKind eventKind,
            ExceptionHandlingInfo handlingInfo, int offset, ExceptionBlock exceptionBlock);

        void ProcessInstruction(ILConversion conversion, ConvertedRoutine entry, ExceptionHandlingInfo info, Instruction instruction, ILGenerator ilGenerator);
    }
}
