using System;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator.IL
{
    public interface GenerationApiMask_I
    {
        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, byte offset);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, sbyte sbyteValue);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, short int16Value);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, ushort int16Value);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, int int32Value);

        void Emit(ConvertedILStream stream, int int32Value);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, Type type);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, MethodInfo type);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, ConstructorInfo type);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, FieldInfo field);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, long int64Value);

        void Emit(ConvertedILStream stream, long int64Value);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, String str);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, float arg);


        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, double arg);

        void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, int[] int32Value);
    }
}
