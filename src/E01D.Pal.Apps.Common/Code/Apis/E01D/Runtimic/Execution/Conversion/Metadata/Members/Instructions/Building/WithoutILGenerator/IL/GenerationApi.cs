using System;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator.IL
{
    public class GenerationApi<TContainer> : ConversionApiNode<TContainer>, GenerationApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
       

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode)
        {
            InternalEmit(conversion, stream, opCode);
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, byte byteValue)
        {
            InternalEmit(conversion, stream, opCode);
            stream.Buffer[stream.Position++] = byteValue;
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, sbyte sbyteValue)
        {
            InternalEmit(conversion, stream, opCode);

            if (sbyteValue < 0)
            {
                stream.Buffer[stream.Position++] = (byte)(256 + sbyteValue);
            }
            else
            {
                stream.Buffer[stream.Position++] = (byte)sbyteValue;
            }
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, short int16Value)
        {

            InternalEmit(conversion, stream, opCode);
            stream.Buffer[stream.Position++] = (byte)int16Value;
            stream.Buffer[stream.Position++] = (byte)(int16Value >> 8);
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, ushort int16Value)
        {

            InternalEmit(conversion, stream, opCode);
            stream.Buffer[stream.Position++] = (byte)int16Value;
            stream.Buffer[stream.Position++] = (byte)(int16Value >> 8);
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, int int32Value)
        {
            InternalEmit(conversion, stream, opCode);
            Emit(stream, int32Value);
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, int[] int32Value)
        {
            InternalEmit(conversion, stream, opCode);
            Emit(stream, int32Value.Length);
            for (int i = 0; i < int32Value.Length; i++)
            {
                Emit(stream, int32Value[i]);
            }
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, long int64Value)
        {
            InternalEmit(conversion, stream, opCode);
            Emit(stream, int64Value);
        }

        public void Emit(ConvertedILStream stream, long int64Value)
        {
            stream.Buffer[stream.Position++] = (byte)int64Value;
            stream.Buffer[stream.Position++] = (byte)(int64Value >> 8);
            stream.Buffer[stream.Position++] = (byte)(int64Value >> 16);
            stream.Buffer[stream.Position++] = (byte)(int64Value >> 24);
            stream.Buffer[stream.Position++] = (byte)(int64Value >> 32);
            stream.Buffer[stream.Position++] = (byte)(int64Value >> 40);
            stream.Buffer[stream.Position++] = (byte)(int64Value >> 48);
            stream.Buffer[stream.Position++] = (byte)(int64Value >> 56);
        }

        public void Emit(ConvertedILStream stream, int int32Value)
        {
            stream.Position = Emit(stream.Buffer, stream.Position, int32Value);
        }


        public int Emit(byte[] buffer, int position, int int32Value)
        {
            buffer[position++] = (byte)int32Value;
            buffer[position++] = (byte)(int32Value >> 8);
            buffer[position++] = (byte)(int32Value >> 16);
            buffer[position++] = (byte)(int32Value >> 24);

            return position;
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, Type type)
        {
            var token = stream.ModuleBuilder.GetTypeToken(type).Token;
            InternalEmit(conversion, stream, opCode);
            RecordToken(stream);        // token will need to be fixed up
            Emit(stream, token); 
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, MethodInfo methodInfo)
        {
            //if (opCode.Equals(OpCodes.Call) || opCode.Equals(OpCodes.Callvirt) || opCode.Equals(OpCodes.Newobj))
            //{
            //    EmitCall(opcode, meth, null);
            //}

            //var methodRef = member as MethodRef;
            //if (methodRef != null)
            //{
            //    return _builder.GetMethodToken(methodRef, methodRef.ExtraParameterTypes).Token;
            //}
            //else
            //{
            //    return _builder.GetMethodToken((MethodInfo)member, optionalParameterTypes: null).Token;
            //}
            //else
            //{
            //    //bool useMethodDef = opCode.Equals(OpCodes.Ldtoken) || opCode.Equals(OpCodes.Ldftn) || opCode.Equals(OpCodes.Ldvirtftn);
            //    //int tk = GetMethodToken(methodInfo, null, useMethodDef);

            //    var token = stream.ModuleBuilder.GetMethodToken(methodInfo).Token;
            //    InternalEmit(conversion, stream, opCode);
            //    RecordToken(stream);        // token will need to be fixed up
            //    Emit(stream, token);
            //}

            //bool useMethodDef = opCode.Equals(OpCodes.Ldtoken) || opCode.Equals(OpCodes.Ldftn) || opCode.Equals(OpCodes.Ldvirtftn);
            //int tk = GetMethodToken(methodInfo, null, useMethodDef);

            int token;


            token = stream.ModuleBuilder.GetMethodToken(methodInfo, null).Token;
            InternalEmit(conversion, stream, opCode);
            RecordToken(stream);        // token will need to be fixed up
            Emit(stream, token);
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, ConstructorInfo type)
        {
            var token = stream.ModuleBuilder.GetConstructorToken(type).Token;
            InternalEmit(conversion, stream, opCode);
            RecordToken(stream);        // token will need to be fixed up
            Emit(stream, token);
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, FieldInfo field)
        {
            var token = stream.ModuleBuilder.GetFieldToken(field).Token;
            InternalEmit(conversion, stream, opCode);
            RecordToken(stream);        // token will need to be fixed up
            Emit(stream, token);
        }

        public void RecordToken(ConvertedILStream stream)
        {
            if (stream.Fixups == null)
            {
                stream.Fixups = new int[8];
            }
            else if (stream.Fixups.Length <= stream.FixupCount)
            {
                stream.Fixups = IncreaseArrayLength(stream.Fixups);
            }

            stream.Fixups[stream.FixupCount++] = stream.Position;
        }

        private int[] IncreaseArrayLength(int[] input)
        {
            int[] newArray = new int[input.Length * 2];

            Array.Copy(input, newArray, input.Length);

            return newArray;
        }

        public void InternalEmit(ILConversion conversion, ConvertedILStream stream, OpCode opCode)
        {
            if (opCode.Size != 1)
            {
                stream.Buffer[stream.Position++] = (byte)(opCode.Value >> 8);
            }

            stream.Buffer[stream.Position++] = (byte)opCode.Value;
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, String str)
        {
            var stringToken = stream.ModuleBuilder.GetStringConstant(str).Token;
            InternalEmit(conversion, stream, opCode);
            Emit(stream, stringToken);
        }

        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, float arg)
        {
            InternalEmit(conversion, stream, opCode);
            var bytes = BitConverter.GetBytes(arg);

            for (int i = 0; i < bytes.Length; i++)
            {
                stream.Buffer[stream.Position++] = bytes[i];
            }
        }

        
        public void Emit(ILConversion conversion, ConvertedILStream stream, OpCode opCode, double arg)
        {
            InternalEmit(conversion, stream, opCode);
            var bytes = BitConverter.GetBytes(arg);

            for (int i = 0; i < bytes.Length; i++)
            {
                stream.Buffer[stream.Position++] = bytes[i];
            }
        }
    }
}
