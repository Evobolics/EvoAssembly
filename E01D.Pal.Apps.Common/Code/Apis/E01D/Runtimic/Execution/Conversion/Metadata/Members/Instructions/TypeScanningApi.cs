using System;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions
{
    public class TypeScanningApi<TContainer> : ConversionApiNode<TContainer>, TypeScanningApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        

        public void EnsureTypes(ILConversion conversion, Collection<Instruction> instructions)
        {
            for (int i = 0; i < instructions.Count; i++)
            {
                var instructionDefinition = instructions[i];


                switch (instructionDefinition.OpCode.Code)
                {
                    case Mono.Cecil.Cil.Code.Add:
                    case Mono.Cecil.Cil.Code.Add_Ovf:
                    case Mono.Cecil.Cil.Code.Add_Ovf_Un:
                    case Mono.Cecil.Cil.Code.And:
                    case Mono.Cecil.Cil.Code.Arglist:
                    {
                        break;
                    }
                    case Mono.Cecil.Cil.Code.Beq:
                    case Mono.Cecil.Cil.Code.Beq_S:
                    case Mono.Cecil.Cil.Code.Bge:
                    case Mono.Cecil.Cil.Code.Bge_S:
                    case Mono.Cecil.Cil.Code.Bge_Un:
                    case Mono.Cecil.Cil.Code.Bge_Un_S:
                    case Mono.Cecil.Cil.Code.Bgt:
                    case Mono.Cecil.Cil.Code.Bgt_S:
                    case Mono.Cecil.Cil.Code.Bgt_Un:
                    case Mono.Cecil.Cil.Code.Bgt_Un_S:
                    case Mono.Cecil.Cil.Code.Ble:
                    case Mono.Cecil.Cil.Code.Ble_S:
                    case Mono.Cecil.Cil.Code.Ble_Un:
                    case Mono.Cecil.Cil.Code.Ble_Un_S:
                    case Mono.Cecil.Cil.Code.Blt:
                    case Mono.Cecil.Cil.Code.Blt_S:
                    case Mono.Cecil.Cil.Code.Blt_Un:
                    case Mono.Cecil.Cil.Code.Blt_Un_S:
                    case Mono.Cecil.Cil.Code.Bne_Un:
                    case Mono.Cecil.Cil.Code.Bne_Un_S:
                    // Unconditional Branching - Long Form
                    case Mono.Cecil.Cil.Code.Br:
                    // Inserts an breakpoint into the IL stream - takes no parameters; does not touch the evaluation stack
                    case Mono.Cecil.Cil.Code.Break:
                    // Conditional Branching - Pop a value from evaluation stack and see if it is 0.  If so, branch.
                    case Mono.Cecil.Cil.Code.Brfalse:
                    // Conditional Branching - Pop a value from evaluation stack and see if it is 0.  If so, branch.
                    case Mono.Cecil.Cil.Code.Brfalse_S:
                    // Conditional Branching - Pop a value from evaluation stack and see if it is 1.  If so, branch.
                    case Mono.Cecil.Cil.Code.Brtrue:
                    // Conditional Branching - Pop a value from evaluation stack and see if it is 1.  If so, branch.
                    case Mono.Cecil.Cil.Code.Brtrue_S:
                    // Unconditional Branching - Short Form
                    case Mono.Cecil.Cil.Code.Br_S:
                    
                    case Mono.Cecil.Cil.Code.Ceq:
                    case Mono.Cecil.Cil.Code.Cgt:
                    case Mono.Cecil.Cil.Code.Cgt_Un:
                    case Mono.Cecil.Cil.Code.Ckfinite:
                    case Mono.Cecil.Cil.Code.Clt:
                    case Mono.Cecil.Cil.Code.Clt_Un:
                    case Mono.Cecil.Cil.Code.Conv_I:
                    case Mono.Cecil.Cil.Code.Conv_I1:
                    case Mono.Cecil.Cil.Code.Conv_I2:
                    case Mono.Cecil.Cil.Code.Conv_I4:
                    case Mono.Cecil.Cil.Code.Conv_I8:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_I:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_I1:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_I1_Un:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_I2:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_I2_Un:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_I4:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_I4_Un:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_I8:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_I8_Un:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_I_Un:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_U:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_U1:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_U1_Un:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_U2:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_U2_Un:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_U4:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_U4_Un:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_U8:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_U8_Un:
                    case Mono.Cecil.Cil.Code.Conv_Ovf_U_Un:
                    case Mono.Cecil.Cil.Code.Conv_R4:
                    case Mono.Cecil.Cil.Code.Conv_R8:
                    case Mono.Cecil.Cil.Code.Conv_R_Un:
                    case Mono.Cecil.Cil.Code.Conv_U:
                    case Mono.Cecil.Cil.Code.Conv_U1:
                    case Mono.Cecil.Cil.Code.Conv_U2:
                    case Mono.Cecil.Cil.Code.Conv_U4:
                    case Mono.Cecil.Cil.Code.Conv_U8:
                    case Mono.Cecil.Cil.Code.Cpblk:
                    case Mono.Cecil.Cil.Code.Div:
                    case Mono.Cecil.Cil.Code.Div_Un:
                    case Mono.Cecil.Cil.Code.Dup:
                    case Mono.Cecil.Cil.Code.Endfilter:
                    case Mono.Cecil.Cil.Code.Endfinally:
                    case Mono.Cecil.Cil.Code.Initblk:
                    case Mono.Cecil.Cil.Code.Ldarg:
                    case Mono.Cecil.Cil.Code.Ldarga:
                    case Mono.Cecil.Cil.Code.Ldarga_S:

                    case Mono.Cecil.Cil.Code.Ldarg_0:
                    case Mono.Cecil.Cil.Code.Ldarg_1:
                    case Mono.Cecil.Cil.Code.Ldarg_2:
                    case Mono.Cecil.Cil.Code.Ldarg_3:
                    case Mono.Cecil.Cil.Code.Ldarg_S:
                    // Constant Loading - Push the supplied integer value onto the stack
                    case Mono.Cecil.Cil.Code.Ldc_I4:
                    // Constant Loading - Push the supplied integer value of 0 onto the stack
                    case Mono.Cecil.Cil.Code.Ldc_I4_0:
                    // Constant Loading - Push the supplied integer value of 1 onto the stack
                    case Mono.Cecil.Cil.Code.Ldc_I4_1:
                    // Constant Loading - Push the supplied integer value of 2 onto the stack
                    case Mono.Cecil.Cil.Code.Ldc_I4_2:
                    // Constant Loading - Push the supplied integer value of 3 onto the stack
                    case Mono.Cecil.Cil.Code.Ldc_I4_3:
                    // Constant Loading - Push the supplied integer value of 4 onto the stack
                    case Mono.Cecil.Cil.Code.Ldc_I4_4:
                    // Constant Loading - Push the supplied integer value of 5 onto the stack
                    case Mono.Cecil.Cil.Code.Ldc_I4_5:
                    // Constant Loading - Push the supplied integer value of 6 onto the stack
                    case Mono.Cecil.Cil.Code.Ldc_I4_6:
                    // Constant Loading - Push the supplied integer value of 7 onto the stack
                    case Mono.Cecil.Cil.Code.Ldc_I4_7:
                    // Constant Loading - Push the supplied integer value of 8 onto the stack
                    case Mono.Cecil.Cil.Code.Ldc_I4_8:
                    case Mono.Cecil.Cil.Code.Ldc_I4_M1:
                    case Mono.Cecil.Cil.Code.Ldc_I4_S:
                    case Mono.Cecil.Cil.Code.Ldc_I8:
                    case Mono.Cecil.Cil.Code.Ldc_R4:
                    case Mono.Cecil.Cil.Code.Ldc_R8:
                    case Mono.Cecil.Cil.Code.Leave:

                    case Mono.Cecil.Cil.Code.Leave_S:
                    case Mono.Cecil.Cil.Code.Ldelem_I:
                    case Mono.Cecil.Cil.Code.Ldelem_I1:
                    case Mono.Cecil.Cil.Code.Ldelem_I2:

                    case Mono.Cecil.Cil.Code.Ldelem_I4:
                    case Mono.Cecil.Cil.Code.Ldelem_I8:
                    case Mono.Cecil.Cil.Code.Ldelem_R4:
                    case Mono.Cecil.Cil.Code.Ldelem_R8:
                    case Mono.Cecil.Cil.Code.Ldelem_Ref:
                    case Mono.Cecil.Cil.Code.Ldelem_U1:
                    case Mono.Cecil.Cil.Code.Ldelem_U2:
                    case Mono.Cecil.Cil.Code.Ldelem_U4:
                    case Mono.Cecil.Cil.Code.Ldfld:
                    case Mono.Cecil.Cil.Code.Ldflda:
                    case Mono.Cecil.Cil.Code.Ldftn:
                    case Mono.Cecil.Cil.Code.Ldlen:
                    case Mono.Cecil.Cil.Code.Ldind_I:
                    case Mono.Cecil.Cil.Code.Ldind_I1:
                    case Mono.Cecil.Cil.Code.Ldind_I2:
                    case Mono.Cecil.Cil.Code.Ldind_I4:
                    case Mono.Cecil.Cil.Code.Ldind_I8:
                    case Mono.Cecil.Cil.Code.Ldind_R4:
                    case Mono.Cecil.Cil.Code.Ldind_R8:
                    case Mono.Cecil.Cil.Code.Ldind_Ref:
                    case Mono.Cecil.Cil.Code.Ldind_U1:
                    case Mono.Cecil.Cil.Code.Ldind_U2:
                    case Mono.Cecil.Cil.Code.Ldind_U4:
                    // Local Load - Push the local value at the location specified by the supplied short value onto the stack
                    case Mono.Cecil.Cil.Code.Ldloc:
                    // Local Load - Push the address of the local value at the location specified by the supplied short value onto the stack
                    case Mono.Cecil.Cil.Code.Ldloca:
                    // Local Load - Push the address of the local value at the location specified by the supplied byte value onto the stack
                    case Mono.Cecil.Cil.Code.Ldloca_S:
                    // Local Load - Push the local value 0 onto the stack
                    case Mono.Cecil.Cil.Code.Ldloc_0:
                    // Local Load - Push the local value 0 onto the stack
                    case Mono.Cecil.Cil.Code.Ldloc_1:
                    // Local Load - Push the local value 0 onto the stack
                    case Mono.Cecil.Cil.Code.Ldloc_2:
                    // Local Load - Push the local value 0 onto the stack
                    case Mono.Cecil.Cil.Code.Ldloc_3:
                    // Local Load - Push the local value at the location specified by the supplied byte value onto the stack
                    case Mono.Cecil.Cil.Code.Ldloc_S:
                    case Mono.Cecil.Cil.Code.Ldnull:
                    case Mono.Cecil.Cil.Code.Ldsfld:
                    case Mono.Cecil.Cil.Code.Ldsflda:
                    case Mono.Cecil.Cil.Code.Ldstr:
                    case Mono.Cecil.Cil.Code.Localloc:
                    case Mono.Cecil.Cil.Code.Mul:
                    case Mono.Cecil.Cil.Code.Mul_Ovf:
                    case Mono.Cecil.Cil.Code.Mul_Ovf_Un:
                    case Mono.Cecil.Cil.Code.Neg:
                    case Mono.Cecil.Cil.Code.Newobj:
                    case Mono.Cecil.Cil.Code.Nop:
                    case Mono.Cecil.Cil.Code.Not:
                    case Mono.Cecil.Cil.Code.Pop:
                    case Mono.Cecil.Cil.Code.Or:
                    case Mono.Cecil.Cil.Code.Readonly:
                    case Mono.Cecil.Cil.Code.Rem:
                    case Mono.Cecil.Cil.Code.Rem_Un:
                    case Mono.Cecil.Cil.Code.Ret:
                    case Mono.Cecil.Cil.Code.Starg:
                    case Mono.Cecil.Cil.Code.Starg_S:
                    case Mono.Cecil.Cil.Code.Stelem_I:
                    case Mono.Cecil.Cil.Code.Stelem_I1:
                    case Mono.Cecil.Cil.Code.Stelem_I2:
                    case Mono.Cecil.Cil.Code.Stelem_I4:
                    case Mono.Cecil.Cil.Code.Stelem_I8:
                    case Mono.Cecil.Cil.Code.Stelem_R4:
                    case Mono.Cecil.Cil.Code.Stelem_R8:
                    case Mono.Cecil.Cil.Code.Stelem_Ref:
                    case Mono.Cecil.Cil.Code.Stind_I:
                    case Mono.Cecil.Cil.Code.Stind_I1:
                    case Mono.Cecil.Cil.Code.Stind_I2:
                    case Mono.Cecil.Cil.Code.Stind_I4:
                    case Mono.Cecil.Cil.Code.Stind_I8:
                    case Mono.Cecil.Cil.Code.Stind_R4:
                    case Mono.Cecil.Cil.Code.Stind_R8:
                    case Mono.Cecil.Cil.Code.Stind_Ref:
                    // Local Store - Pops the value on the stack and stores it in local location specified by the supplied short value onto the stack
                    case Mono.Cecil.Cil.Code.Stloc:
                    // Local Store - Pops the value on the stack and stores it in local 0
                    case Mono.Cecil.Cil.Code.Stloc_0:
                    // Local Store - Pops the value on the stack and stores it in local 1
                    case Mono.Cecil.Cil.Code.Stloc_1:
                    // Local Store - Pops the value on the stack and stores it in local 2
                    case Mono.Cecil.Cil.Code.Stloc_2:
                    // Local Store - Pops the value on the stack and stores it in local 3
                    case Mono.Cecil.Cil.Code.Stloc_3:
                    // Local Store - Pops the value on the stack and stores it in local location specified by the supplied byte value onto the stack
                    case Mono.Cecil.Cil.Code.Stloc_S:
                    case Mono.Cecil.Cil.Code.Shl:
                    case Mono.Cecil.Cil.Code.Shr:
                    case Mono.Cecil.Cil.Code.Shr_Un:
                    case Mono.Cecil.Cil.Code.Sub:
                    case Mono.Cecil.Cil.Code.Sub_Ovf:
                    case Mono.Cecil.Cil.Code.Sub_Ovf_Un:
                    case Mono.Cecil.Cil.Code.Volatile:
                    case Mono.Cecil.Cil.Code.Xor:
                    {
                        break;
                    }
                    case Mono.Cecil.Cil.Code.Call:
                    {
                        //var memberReference = instructionDefinition.Operand as MemberReference;

                        var methodReference = (MethodReference) instructionDefinition.Operand;

                        if (methodReference is Mono.Cecil.GenericInstanceMethod genericMethodReference)
                        {
                            for (int j = 0; j < genericMethodReference.GenericArguments.Count; j++)
                            {
                                var genericArgument = genericMethodReference.GenericArguments[j];

                                Types.Scanning.EnsureType(conversion, genericArgument);
                            }
                        }

                        Types.Scanning.EnsureType(conversion, methodReference.DeclaringType);


                            break;
                    }
                    case Mono.Cecil.Cil.Code.Callvirt:
                    {
                        //var memberReference = instructionDefinition.Operand as MemberReference;

                        var methodReference = (MethodReference)instructionDefinition.Operand;

                        if (methodReference is Mono.Cecil.GenericInstanceMethod genericMethodReference)
                        {
                            for (int j = 0; j < genericMethodReference.GenericArguments.Count; j++)
                            {
                                var genericArgument = genericMethodReference.GenericArguments[j];

                                Types.Scanning.EnsureType(conversion, genericArgument);
                            }
                        }

                        Types.Scanning.EnsureType(conversion, methodReference.DeclaringType);

                        break;
                    }
                    case Mono.Cecil.Cil.Code.Box:
                    {
                        var typeReference = instructionDefinition.Operand as TypeReference;
                        Types.Scanning.EnsureType(conversion, typeReference);

                            break;
                    }
                    case Mono.Cecil.Cil.Code.Castclass:
                    {
                        var typeReference = instructionDefinition.Operand as TypeReference;
                        Types.Scanning.EnsureType(conversion, typeReference);

                            break;
                    }

                    case Mono.Cecil.Cil.Code.Constrained:
                    {
                        var typeReference = instructionDefinition.Operand as TypeReference;

                        Types.Scanning.EnsureType(conversion, typeReference);

                            break;
                    }

                    case Mono.Cecil.Cil.Code.Cpobj:
                    {
                        //throw new NotImplementedException();
                        //    //ilGenerator.Emit(OpCodes.Cpobj);
                        //    //break;
                        throw new Exception($"Code {instructionDefinition.OpCode.Code.ToString()} not handled.");
                    }
                    case Mono.Cecil.Cil.Code.Initobj:
                    {
                        var typeReference = instructionDefinition.Operand as TypeReference;

                        Types.Scanning.EnsureType(conversion, typeReference);

                        break;
                        }
                    case Mono.Cecil.Cil.Code.Ldelema:
                    {
                        var typeReference = instructionDefinition.Operand as TypeReference;

                        Types.Scanning.EnsureType(conversion, typeReference);

                            break;
                    }
                    case Mono.Cecil.Cil.Code.Ldelem_Any:
                    {
                        //throw new NotSupportedException();

                        throw new Exception($"Code {instructionDefinition.OpCode.Code.ToString()} not handled.");
                    }
                    case Mono.Cecil.Cil.Code.Ldtoken:
                    {
                        var typeReference = instructionDefinition.Operand as TypeReference;

                        Types.Scanning.EnsureType(conversion, typeReference);

                        break;
                    }

                    case Mono.Cecil.Cil.Code.Newarr:
                    {
                        var typeReference = instructionDefinition.Operand as TypeReference;

                        Types.Scanning.EnsureType(conversion, typeReference);

                        break;
                    }


                    case Mono.Cecil.Cil.Code.Sizeof:
                    {
                        var typeReference = instructionDefinition.Operand as TypeReference;

                        Types.Scanning.EnsureType(conversion, typeReference);

                            break;
                    }


                    case Mono.Cecil.Cil.Code.Stelem_Any:
                    {
                        //throw new NotSupportedException();
                        throw new Exception($"Code {instructionDefinition.OpCode.Code.ToString()} not handled.");
                    }
                    case Mono.Cecil.Cil.Code.Stfld:
                    {
                        FieldReference fieldReference = (FieldReference) instructionDefinition.Operand;

                        Types.Scanning.EnsureType(conversion, fieldReference.DeclaringType);

                        break;
                    }
                    case Mono.Cecil.Cil.Code.Stsfld:
                    {
                        FieldReference fieldReference = (FieldReference)instructionDefinition.Operand;

                        Types.Scanning.EnsureType(conversion, fieldReference.DeclaringType);

                        break;
                    }


                    case Mono.Cecil.Cil.Code.Throw:
                    {
                        var typeReference = instructionDefinition.Operand as TypeReference;

                        Types.Scanning.EnsureType(conversion, typeReference);

                            break;
                    }

                    case Mono.Cecil.Cil.Code.Unbox:
                    {
                        var typeReference = instructionDefinition.Operand as TypeReference;

                        Types.Scanning.EnsureType(conversion, typeReference);

                        break;
                    }
                    case Mono.Cecil.Cil.Code.Unbox_Any:
                    {
                        var typeReference = instructionDefinition.Operand as TypeReference;

                        Types.Scanning.EnsureType(conversion, typeReference);
                        

                        break;
                    }


                    default:
                    {
                        throw new Exception($"Code {instructionDefinition.OpCode.Code.ToString()} not handled when processing types..");
                    }
                }
            }
        }
    }
}
