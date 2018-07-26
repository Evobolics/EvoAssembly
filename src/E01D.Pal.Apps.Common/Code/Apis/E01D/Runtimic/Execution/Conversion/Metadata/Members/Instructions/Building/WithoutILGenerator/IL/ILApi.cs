using System;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Cil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using OpCode = System.Reflection.Emit.OpCode;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator.IL
{
    public class ILApi<TContainer> : ConversionApiNode<TContainer>, ILApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public GenerationApi_I<TContainer> Generation { get; set; }

        GenerationApiMask_I ILApiMask_I.Generation => Generation;

        public ConvertedILStream EmitILStream(ILConversion conversion, ConvertedEmittedConstructor convertedConstructor)
        {
            var methodDefinition = (MethodDefinition)convertedConstructor.MethodReference;

            var ilStream = EmitOpCodes(conversion, convertedConstructor, methodDefinition);

            return ilStream;
        }

        private ConvertedILStream EmitOpCodes(ILConversion conversion, ConvertedEmittedConstructor convertedConstructor, MethodDefinition methodDefinition)
        {
            var stream = new ConvertedILStream
            {
                Buffer = new byte[methodDefinition.Body.CodeSize],
                ModuleBuilder = convertedConstructor.DeclaringType.Module.ModuleBuilder
            };

            for (int iInstruction = 0; iInstruction < methodDefinition.Body.Instructions.Count; iInstruction++)
            {
                var instructionDefinition = methodDefinition.Body.Instructions[iInstruction];

                EmitOpCode(conversion, convertedConstructor, methodDefinition, stream, instructionDefinition);
            }

            return stream;
        }

        private void EmitOpCode(ILConversion conversion, ConvertedEmittedConstructor convertedConstructor, 
            MethodDefinition methodDefinition,
            ConvertedILStream stream,
            Instruction instructionDefinition)
        {
            OpCode opCode = Cecil.Metadata.Instructions.ConvertOpCode(instructionDefinition.OpCode.Code);

            switch (instructionDefinition.OpCode.Code)
            {
                case Libs.Mono.Cecil.Cil.Code.Add:
                case Libs.Mono.Cecil.Cil.Code.Add_Ovf:
                case Libs.Mono.Cecil.Cil.Code.Add_Ovf_Un:
                case Libs.Mono.Cecil.Cil.Code.And:
                case Libs.Mono.Cecil.Cil.Code.Arglist:
                case Libs.Mono.Cecil.Cil.Code.Break:
                case Libs.Mono.Cecil.Cil.Code.Ceq:
                case Libs.Mono.Cecil.Cil.Code.Cgt:
                case Libs.Mono.Cecil.Cil.Code.Cgt_Un:
                case Libs.Mono.Cecil.Cil.Code.Ckfinite:
                case Libs.Mono.Cecil.Cil.Code.Clt:
                case Libs.Mono.Cecil.Cil.Code.Clt_Un:
                case Libs.Mono.Cecil.Cil.Code.Conv_I:
                case Libs.Mono.Cecil.Cil.Code.Conv_I1:
                case Libs.Mono.Cecil.Cil.Code.Conv_I2:
                case Libs.Mono.Cecil.Cil.Code.Conv_I4:
                case Libs.Mono.Cecil.Cil.Code.Conv_I8:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I1:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I1_Un:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I2:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I2_Un:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I4:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I4_Un:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I8:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I8_Un:                
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I_Un:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U1:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U1_Un:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U2:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U2_Un:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U4:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U4_Un:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U8:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U8_Un:
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U_Un:
                case Libs.Mono.Cecil.Cil.Code.Conv_R4:
                case Libs.Mono.Cecil.Cil.Code.Conv_R8:
                case Libs.Mono.Cecil.Cil.Code.Conv_R_Un:                
                case Libs.Mono.Cecil.Cil.Code.Conv_U:
                case Libs.Mono.Cecil.Cil.Code.Conv_U1:
                case Libs.Mono.Cecil.Cil.Code.Conv_U2:
                case Libs.Mono.Cecil.Cil.Code.Conv_U4:
                case Libs.Mono.Cecil.Cil.Code.Conv_U8:
                case Libs.Mono.Cecil.Cil.Code.Cpblk:
                case Libs.Mono.Cecil.Cil.Code.Div:
                case Libs.Mono.Cecil.Cil.Code.Div_Un:
                case Libs.Mono.Cecil.Cil.Code.Dup:
                case Libs.Mono.Cecil.Cil.Code.Endfilter:
                case Libs.Mono.Cecil.Cil.Code.Endfinally:
                case Libs.Mono.Cecil.Cil.Code.Initblk:
                case Libs.Mono.Cecil.Cil.Code.Ldarg_0:
                case Libs.Mono.Cecil.Cil.Code.Ldarg_1:
                case Libs.Mono.Cecil.Cil.Code.Ldarg_2:
                case Libs.Mono.Cecil.Cil.Code.Ldarg_3:
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_0:
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_1:
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_2:
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_3:
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_4:
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_5:
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_6:
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_7:
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_8:
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_M1:
                case Libs.Mono.Cecil.Cil.Code.Ldnull:
                case Libs.Mono.Cecil.Cil.Code.Ldelem_Any:
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I:
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I1:
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I2:
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I4:
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I8:
                case Libs.Mono.Cecil.Cil.Code.Ldelem_R4:
                case Libs.Mono.Cecil.Cil.Code.Ldelem_R8:
                case Libs.Mono.Cecil.Cil.Code.Ldelem_Ref:
                case Libs.Mono.Cecil.Cil.Code.Ldelem_U1:
                case Libs.Mono.Cecil.Cil.Code.Ldelem_U2:
                case Libs.Mono.Cecil.Cil.Code.Ldelem_U4:
                case Libs.Mono.Cecil.Cil.Code.Ldlen:
                case Libs.Mono.Cecil.Cil.Code.Ldind_I:
                case Libs.Mono.Cecil.Cil.Code.Ldind_I1:
                case Libs.Mono.Cecil.Cil.Code.Ldind_I2:
                case Libs.Mono.Cecil.Cil.Code.Ldind_I4:
                case Libs.Mono.Cecil.Cil.Code.Ldind_I8:
                case Libs.Mono.Cecil.Cil.Code.Ldind_R4:
                case Libs.Mono.Cecil.Cil.Code.Ldind_R8:
                case Libs.Mono.Cecil.Cil.Code.Ldind_Ref:
                case Libs.Mono.Cecil.Cil.Code.Ldind_U1:
                case Libs.Mono.Cecil.Cil.Code.Ldind_U2:
                case Libs.Mono.Cecil.Cil.Code.Ldind_U4:
                case Libs.Mono.Cecil.Cil.Code.Ldloc_0:
                case Libs.Mono.Cecil.Cil.Code.Ldloc_1:
                case Libs.Mono.Cecil.Cil.Code.Ldloc_2:
                case Libs.Mono.Cecil.Cil.Code.Ldloc_3:
                case Libs.Mono.Cecil.Cil.Code.Localloc:
                case Libs.Mono.Cecil.Cil.Code.Mul:
                case Libs.Mono.Cecil.Cil.Code.Mul_Ovf:
                case Libs.Mono.Cecil.Cil.Code.Mul_Ovf_Un:
                case Libs.Mono.Cecil.Cil.Code.Neg:
                case Libs.Mono.Cecil.Cil.Code.Nop:
                case Libs.Mono.Cecil.Cil.Code.Not:
                case Libs.Mono.Cecil.Cil.Code.Pop:
                case Libs.Mono.Cecil.Cil.Code.Or:
                case Libs.Mono.Cecil.Cil.Code.Readonly:
                case Libs.Mono.Cecil.Cil.Code.Refanytype:
                case Libs.Mono.Cecil.Cil.Code.Rem:
                case Libs.Mono.Cecil.Cil.Code.Rem_Un:
                case Libs.Mono.Cecil.Cil.Code.Ret:
                case Libs.Mono.Cecil.Cil.Code.Rethrow:
                case Libs.Mono.Cecil.Cil.Code.Stelem_Any:
                case Libs.Mono.Cecil.Cil.Code.Stelem_I:
                case Libs.Mono.Cecil.Cil.Code.Stelem_I1:
                case Libs.Mono.Cecil.Cil.Code.Stelem_I2:
                case Libs.Mono.Cecil.Cil.Code.Stelem_I4:
                case Libs.Mono.Cecil.Cil.Code.Stelem_I8:
                case Libs.Mono.Cecil.Cil.Code.Stelem_R4:
                case Libs.Mono.Cecil.Cil.Code.Stelem_R8:
                case Libs.Mono.Cecil.Cil.Code.Stelem_Ref:
                case Libs.Mono.Cecil.Cil.Code.Stind_I:
                case Libs.Mono.Cecil.Cil.Code.Stind_I1:
                case Libs.Mono.Cecil.Cil.Code.Stind_I2:
                case Libs.Mono.Cecil.Cil.Code.Stind_I4:
                case Libs.Mono.Cecil.Cil.Code.Stind_I8:
                case Libs.Mono.Cecil.Cil.Code.Stind_R4:
                case Libs.Mono.Cecil.Cil.Code.Stind_R8:
                case Libs.Mono.Cecil.Cil.Code.Stind_Ref:
                case Libs.Mono.Cecil.Cil.Code.Stloc_0:
                case Libs.Mono.Cecil.Cil.Code.Stloc_1:
                case Libs.Mono.Cecil.Cil.Code.Stloc_2:
                case Libs.Mono.Cecil.Cil.Code.Stloc_3:
                case Libs.Mono.Cecil.Cil.Code.Shl:
                case Libs.Mono.Cecil.Cil.Code.Shr:
                case Libs.Mono.Cecil.Cil.Code.Shr_Un:
                case Libs.Mono.Cecil.Cil.Code.Sub:
                case Libs.Mono.Cecil.Cil.Code.Sub_Ovf:
                case Libs.Mono.Cecil.Cil.Code.Sub_Ovf_Un:
                case Libs.Mono.Cecil.Cil.Code.Tail:
                case Libs.Mono.Cecil.Cil.Code.Throw:
                case Libs.Mono.Cecil.Cil.Code.Volatile:
                case Libs.Mono.Cecil.Cil.Code.Xor:
                {
                    Generation.Emit(conversion, stream, opCode);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Beq_S:
                case Libs.Mono.Cecil.Cil.Code.Bge_S:
                case Libs.Mono.Cecil.Cil.Code.Bge_Un_S:
                case Libs.Mono.Cecil.Cil.Code.Bgt_Un_S:
                case Libs.Mono.Cecil.Cil.Code.Bgt_S:
                case Libs.Mono.Cecil.Cil.Code.Ble_S:
                case Libs.Mono.Cecil.Cil.Code.Ble_Un_S:
                case Libs.Mono.Cecil.Cil.Code.Blt_S:
                case Libs.Mono.Cecil.Cil.Code.Blt_Un_S:
                case Libs.Mono.Cecil.Cil.Code.Bne_Un_S:
                case Libs.Mono.Cecil.Cil.Code.Brfalse_S:
                case Libs.Mono.Cecil.Cil.Code.Brtrue_S:
                case Libs.Mono.Cecil.Cil.Code.Br_S:
                case Libs.Mono.Cecil.Cil.Code.Leave_S:
                {
                    Generation.Emit(conversion, stream, opCode, (byte)((Instruction)instructionDefinition.Operand).Offset);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Beq:
                case Libs.Mono.Cecil.Cil.Code.Bge:
                case Libs.Mono.Cecil.Cil.Code.Bge_Un:
                case Libs.Mono.Cecil.Cil.Code.Bgt:
                case Libs.Mono.Cecil.Cil.Code.Bgt_Un:
                case Libs.Mono.Cecil.Cil.Code.Ble:
                case Libs.Mono.Cecil.Cil.Code.Ble_Un:
                case Libs.Mono.Cecil.Cil.Code.Blt:
                case Libs.Mono.Cecil.Cil.Code.Blt_Un:
                case Libs.Mono.Cecil.Cil.Code.Bne_Un:
                case Libs.Mono.Cecil.Cil.Code.Br:
                case Libs.Mono.Cecil.Cil.Code.Brfalse:
                case Libs.Mono.Cecil.Cil.Code.Brtrue:
                case Libs.Mono.Cecil.Cil.Code.Leave:
                {
                    Generation.Emit(conversion, stream, opCode, (int)((Instruction)instructionDefinition.Operand).Offset);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Box:
                case Libs.Mono.Cecil.Cil.Code.Castclass:
                case Libs.Mono.Cecil.Cil.Code.Constrained:
                case Libs.Mono.Cecil.Cil.Code.Cpobj:
                case Libs.Mono.Cecil.Cil.Code.Initobj:
                case Libs.Mono.Cecil.Cil.Code.Isinst:
                case Libs.Mono.Cecil.Cil.Code.Ldelema:
                case Libs.Mono.Cecil.Cil.Code.Ldobj:
                case Libs.Mono.Cecil.Cil.Code.Mkrefany:
                case Libs.Mono.Cecil.Cil.Code.Newarr:
                case Libs.Mono.Cecil.Cil.Code.Refanyval:
                case Libs.Mono.Cecil.Cil.Code.Sizeof:
                case Libs.Mono.Cecil.Cil.Code.Stobj:
                case Libs.Mono.Cecil.Cil.Code.Unbox:
                case Libs.Mono.Cecil.Cil.Code.Unbox_Any:
                {
                    var type = Execution.Types.Ensuring.EnsureToType(conversion.Model, new BoundEnsureContext()
                    {
                        TypeReference = (TypeReference)instructionDefinition.Operand,
                        MethodReference = methodDefinition,
                        RoutineDeclaringType = convertedConstructor.DeclaringType
                    });
                        
                    Generation.Emit(conversion, stream, opCode, type);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarg:
                case Libs.Mono.Cecil.Cil.Code.Ldarga:
                case Libs.Mono.Cecil.Cil.Code.Starg:
                {
                    if (instructionDefinition.Operand is ParameterDefinition parameter)
                    {
                        ConvertedMethodParameterMask_I convertedParameter = GetParameter(convertedConstructor, parameter);

                        Generation.Emit(conversion, stream, opCode, (ushort)convertedParameter.Position);
                    }
                    else
                    {
                        Generation.Emit(conversion, stream, opCode, (ushort)instructionDefinition.Operand);
                    }
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarga_S:
                case Libs.Mono.Cecil.Cil.Code.Ldarg_S:
                case Libs.Mono.Cecil.Cil.Code.Starg_S:
                {
                    if (instructionDefinition.Operand is ParameterDefinition parameter)
                    {
                        ConvertedMethodParameterMask_I convertedParameter = GetParameter(convertedConstructor, parameter);

                        Generation.Emit(conversion, stream, opCode, (byte)convertedParameter.Position);
                    }
                    else
                    {
                        Generation.Emit(conversion, stream, opCode, (byte)instructionDefinition.Operand);
                    }

                    break;
                }
                // Constant Loading - Push the supplied integer value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4:
                {
                    Generation.Emit(conversion, stream, opCode, (int)instructionDefinition.Operand);
                    break;
                }

                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_S:
                {
                    Generation.Emit(conversion, stream, opCode, (sbyte)instructionDefinition.Operand);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_I8:
                {
                    

                    Generation.Emit(conversion, stream, opCode, (long)instructionDefinition.Operand);

                    break;
                }
                // Local Load - Push the local value at the location specified by the supplied short value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc:
                case Libs.Mono.Cecil.Cil.Code.Ldloca:
                case Libs.Mono.Cecil.Cil.Code.Stloc:
                    {
                        if (instructionDefinition.Operand is VariableDefinition variable)
                        {
                            Generation.Emit(conversion, stream, opCode, (ushort)variable.Index);
                        }
                        else
                        {
                            Generation.Emit(conversion, stream, opCode, (ushort)instructionDefinition.Operand);
                        }

                        break;
                }
                
                // Local Load - Push the address of the local value at the location specified by the supplied byte value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloca_S:
                case Libs.Mono.Cecil.Cil.Code.Ldloc_S:
                case Libs.Mono.Cecil.Cil.Code.Stloc_S:
                    {
                    if (instructionDefinition.Operand is VariableDefinition variable)
                    {
                        Generation.Emit(conversion, stream, opCode, (byte)variable.Index);
                    }
                    else
                    {
                        Generation.Emit(conversion, stream, opCode, (byte)instructionDefinition.Operand);
                    }

                    break;
                }

                
                case Libs.Mono.Cecil.Cil.Code.Ldstr:
                {
                    Generation.Emit(conversion, stream, opCode, (string)instructionDefinition.Operand);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_R4:
                {
                    Generation.Emit(conversion, stream, opCode, (float)instructionDefinition.Operand);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_R8:
                {
                    Generation.Emit(conversion, stream, opCode, (double)instructionDefinition.Operand);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Unaligned:
                {
                    Generation.Emit(conversion, stream, opCode, (byte)instructionDefinition.Operand);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Callvirt:
                case Libs.Mono.Cecil.Cil.Code.Call:
                {
                    if (!Members.GetMemberInfo(conversion, convertedConstructor.DeclaringType, convertedConstructor, (MethodReference)instructionDefinition.Operand,
                        out MemberInfo memberInfo))
                    {
                        throw new Exception("Could not find member.  Need to gracefully exit and comeback.");
                    }

                    if (memberInfo is ConstructorInfo constructor)
                    {
                        Generation.Emit(conversion, stream, opCode, constructor);
                    }
                    else if (memberInfo is MethodInfo methodInfo)
                    {
                        Generation.Emit(conversion, stream, opCode, methodInfo);
                    }
                    else
                    {
                        throw new System.Exception("Not a constructor or  method");
                    }

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Calli:
                {
                    throw new System.NotSupportedException("Calli instruction not supported yet.");
                }
                case Libs.Mono.Cecil.Cil.Code.Jmp:
                case Libs.Mono.Cecil.Cil.Code.Ldftn:
                case Libs.Mono.Cecil.Cil.Code.Ldvirtftn:
                {
                    if (!Members.GetMemberInfo(conversion, convertedConstructor.DeclaringType, convertedConstructor, (MethodReference)instructionDefinition.Operand,
                        out MemberInfo memberInfo))
                    {
                        throw new Exception("Could not find member.  Need to gracefully exit and comeback.");
                    }

                    Generation.Emit(conversion, stream, opCode, (MethodInfo)memberInfo);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldfld:
                case Libs.Mono.Cecil.Cil.Code.Ldflda:
                case Libs.Mono.Cecil.Cil.Code.Ldsfld:
                case Libs.Mono.Cecil.Cil.Code.Ldsflda:
                case Libs.Mono.Cecil.Cil.Code.Stfld:
                case Libs.Mono.Cecil.Cil.Code.Stsfld:
                {
                    var fieldInfo = Models.Fields.ResolveFieldReference(conversion, 
                        convertedConstructor.DeclaringType, (FieldReference)instructionDefinition.Operand);

                    Generation.Emit(conversion, stream, opCode, fieldInfo);

                    break;
                }

                case Libs.Mono.Cecil.Cil.Code.Ldtoken:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    System.Type resolvedType;

                    if (typeReference is GenericParameter genericParameter)
                    {
                        // This hard cast is safe as constructors do not have generic parameters.
                        resolvedType = Instructions.GetGenericParameterType(conversion, convertedConstructor.DeclaringType, convertedConstructor, genericParameter);
                    }
                    else
                    {
                        resolvedType = Execution.Types.Ensuring.EnsureToType(conversion.Model, typeReference);
                    }


                    Generation.Emit(conversion, stream, opCode, resolvedType);

                    break;
                }
               
               
                case Libs.Mono.Cecil.Cil.Code.Newobj:
                {
                    var methodReference = (MethodReference)instructionDefinition.Operand;

                        // Created during pre-scan
                        //var convertedInstruction = convertedConstructor.ConvertedInstructions[instructionDefinition.Offset];

                        // how does the member reference declaring type be resolved?
                        //var declaringBound = convertedInstruction.OperandDeclaringType;

                    var operandDeclaringType = Execution.Types.Ensuring.EnsureBound(conversion.Model, methodReference.DeclaringType);

                        var found = Constructors.Getting.GetConstructor(conversion, convertedConstructor.DeclaringType, operandDeclaringType, methodReference, out MemberInfo memberInfo);

                    if (!found)
                    {
                        throw new Exception("Constructor not found.  This needs to gracefully exit and comeback.");
                    }

                    if (memberInfo is ConstructorInfo constructorInfo)
                    {
                        Generation.Emit(conversion, stream, opCode, constructorInfo);
                    }
                    else if (memberInfo is MethodInfo methodInfo)
                    {
                            // Possible for multidimensional array creation
                        Generation.Emit(conversion, stream, opCode, methodInfo);
                    }
                    else
                    {
                        throw new System.Exception("Not a constructor or  method");
                    }

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Switch:
                {
                        //if (!switchEntries.TryGetValue(instructionDefinition.Offset, out ConvertedLabel switchEntry))
                        //{
                        //    throw new Exception($"Did not find a switch statement at offset {instructionDefinition.Offset}.");
                        //}

                    var instructions = (Instruction[])instructionDefinition.Operand;
                    int[] offsets = new int[instructions.Length];
                    for (int i = 0; i < instructions.Length; i++)
                    {
                        offsets[i]= instructions[i].Offset;
                    }

                    

                    Generation.Emit(conversion, stream, opCode, offsets);

                    break;
                }
                default:
                {
                    //No = 214,
                    throw new System.Exception($"Code {instructionDefinition.OpCode.Code.ToString()} not handled.");
                }
            }
        }
        private ConvertedMethodParameterMask_I GetParameter(ConvertedRoutine routine, ParameterDefinition parameter)
        {
            if (!routine.Parameters.ByName.TryGetValue(parameter.Name, out SemanticRoutineParameterMask_I semanticParameter))
            {
                throw new System.Exception(
                    $"Could not find parameter {parameter.Name} in method {routine.Name}.");
            }

            if (!(semanticParameter is ConvertedMethodParameterMask_I convertedParameter))
            {
                throw new System.Exception(
                    $"The parameter {parameter.Name} in method {routine.Name} is not a convertible parameter.");
            }

            return convertedParameter;
        }

    }
}
