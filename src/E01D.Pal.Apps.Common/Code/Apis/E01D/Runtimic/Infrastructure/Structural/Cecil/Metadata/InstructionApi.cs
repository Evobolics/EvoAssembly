using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
    public class InstructionApi<TContainer> : CecilApiNode<TContainer>, InstructionApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public OpCode ConvertOpCode(Libs.Mono.Cecil.Cil.Code opCodeCode)
        {
            switch (opCodeCode)
            {
                case Libs.Mono.Cecil.Cil.Code.Add:
                {
                    return OpCodes.Add;
                }
                case Libs.Mono.Cecil.Cil.Code.Add_Ovf:
                {
                    return OpCodes.Add_Ovf;
                }

                case Libs.Mono.Cecil.Cil.Code.Add_Ovf_Un:
                {
                    return OpCodes.Add_Ovf_Un;
                }
                case Libs.Mono.Cecil.Cil.Code.And:
                {
                    return OpCodes.And;
                }
                case Libs.Mono.Cecil.Cil.Code.Arglist:
                {
                    return OpCodes.Arglist;
                }
                case Libs.Mono.Cecil.Cil.Code.Beq:
                {
                    return OpCodes.Beq;
                }
                case Libs.Mono.Cecil.Cil.Code.Beq_S:
                {
                    return OpCodes.Beq_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Bge:
                {
                    return OpCodes.Bge;
                }
                case Libs.Mono.Cecil.Cil.Code.Bge_S:
                {
                    return OpCodes.Bge_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Bge_Un:
                {
                    return OpCodes.Bge_Un;
                }
                case Libs.Mono.Cecil.Cil.Code.Bge_Un_S:
                {
                    return OpCodes.Bge_Un_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Bgt:
                {
                    return OpCodes.Bgt;
                }
                case Libs.Mono.Cecil.Cil.Code.Bgt_S:
                {
                    return OpCodes.Bgt_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Bgt_Un:
                {
                    return OpCodes.Bgt_Un;
                }
                case Libs.Mono.Cecil.Cil.Code.Bgt_Un_S:
                {
                    return OpCodes.Bgt_Un_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Ble:
                {
                    return OpCodes.Ble;
                }
                case Libs.Mono.Cecil.Cil.Code.Ble_S:
                {
                    return OpCodes.Ble_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Ble_Un:
                {
                    return OpCodes.Ble_Un;
                }
                case Libs.Mono.Cecil.Cil.Code.Ble_Un_S:
                {
                    return OpCodes.Ble_Un_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Blt:
                {
                    return OpCodes.Blt;
                }
                case Libs.Mono.Cecil.Cil.Code.Blt_S:
                {
                    return OpCodes.Blt_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Blt_Un:
                {
                    return OpCodes.Blt_Un;
                }
                case Libs.Mono.Cecil.Cil.Code.Blt_Un_S:
                {
                    return OpCodes.Blt_Un_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Bne_Un:
                {
                    return OpCodes.Bne_Un;
                }
                case Libs.Mono.Cecil.Cil.Code.Bne_Un_S:
                {
                    return OpCodes.Bne_Un_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Box:
                {
                    return OpCodes.Box;
                }

                // Unconditional Branching - Long Form
                case Libs.Mono.Cecil.Cil.Code.Br:
                {
                    return OpCodes.Br;
                }
                // Inserts an breakpoint into the IL stream - takes no parameters; does not touch the evaluation stack
                case Libs.Mono.Cecil.Cil.Code.Break:
                {
                    return OpCodes.Break;
                }
                // Conditional Branching - Pop a value from evaluation stack and see if it is 0.  If so, branch.
                case Libs.Mono.Cecil.Cil.Code.Brfalse:
                {
                    return OpCodes.Brfalse;
                }
                // Conditional Branching - Pop a value from evaluation stack and see if it is 0.  If so, branch.
                case Libs.Mono.Cecil.Cil.Code.Brfalse_S:
                {
                    return OpCodes.Brfalse_S;
                }

                // Conditional Branching - Pop a value from evaluation stack and see if it is 1.  If so, branch.
                case Libs.Mono.Cecil.Cil.Code.Brtrue:
                {
                    return OpCodes.Brtrue;
                }
                // Conditional Branching - Pop a value from evaluation stack and see if it is 1.  If so, branch.
                case Libs.Mono.Cecil.Cil.Code.Brtrue_S:
                {
                    return OpCodes.Brtrue_S;
                }
                // Unconditional Branching - Short Form
                case Libs.Mono.Cecil.Cil.Code.Br_S:
                {
                    return OpCodes.Br_S;
                }

                case Libs.Mono.Cecil.Cil.Code.Call:
                {
                    return OpCodes.Call;
                }
                case Libs.Mono.Cecil.Cil.Code.Calli:
                {
                    return OpCodes.Calli;
                }
                case Libs.Mono.Cecil.Cil.Code.Callvirt:
                {
                    return OpCodes.Callvirt;
                }
                case Libs.Mono.Cecil.Cil.Code.Castclass:
                {
                    return OpCodes.Castclass;
                }

                case Libs.Mono.Cecil.Cil.Code.Ceq:
                {
                    return OpCodes.Ceq;
                }
                case Libs.Mono.Cecil.Cil.Code.Cgt:
                {
                    return OpCodes.Cgt;
                }
                case Libs.Mono.Cecil.Cil.Code.Cgt_Un:
                {
                    return OpCodes.Cgt_Un;
                }
                case Libs.Mono.Cecil.Cil.Code.Ckfinite:
                {
                    return OpCodes.Ckfinite;

                }
                case Libs.Mono.Cecil.Cil.Code.Clt:
                {
                    return OpCodes.Clt;

                }
                case Libs.Mono.Cecil.Cil.Code.Clt_Un:
                {
                    return OpCodes.Clt_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Constrained:
                {
                    return OpCodes.Constrained;


                }
                case Libs.Mono.Cecil.Cil.Code.Conv_I:
                {
                    return OpCodes.Conv_I;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_I1:
                {
                    return OpCodes.Conv_I1;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_I2:
                {
                    return OpCodes.Conv_I2;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_I4:
                {
                    return OpCodes.Conv_I4;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_I8:
                {
                    return OpCodes.Conv_I8;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I:
                {
                    return OpCodes.Conv_Ovf_I;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I1:
                {
                    return OpCodes.Conv_Ovf_I1;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I1_Un:
                {
                    return OpCodes.Conv_Ovf_I1_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I2:
                {
                    return OpCodes.Conv_Ovf_I2;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I2_Un:
                {
                    return OpCodes.Conv_Ovf_I2_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I4:
                {
                    return OpCodes.Conv_Ovf_I4;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I4_Un:
                {
                    return OpCodes.Conv_Ovf_I4_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I8:
                {
                    return OpCodes.Conv_Ovf_I8;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I8_Un:
                {
                    return OpCodes.Conv_Ovf_I8_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I_Un:
                {
                    return OpCodes.Conv_Ovf_I_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U:
                {
                    return OpCodes.Conv_Ovf_U;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U1:
                {
                    return OpCodes.Conv_Ovf_U1;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U1_Un:
                {
                    return OpCodes.Conv_Ovf_U1_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U2:
                {
                    return OpCodes.Conv_Ovf_U2;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U2_Un:
                {
                    return OpCodes.Conv_Ovf_U2_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U4:
                {
                    return OpCodes.Conv_Ovf_U4;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U4_Un:
                {
                    return OpCodes.Conv_Ovf_U4_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U8:
                {
                    return OpCodes.Conv_Ovf_U8;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U8_Un:
                {
                    return OpCodes.Conv_Ovf_U8_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U_Un:
                {
                    return OpCodes.Conv_Ovf_U_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_R4:
                {
                    return OpCodes.Conv_R4;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_R8:
                {
                    return OpCodes.Conv_R8;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_R_Un:
                {
                    return OpCodes.Conv_R_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_U:
                {
                    return OpCodes.Conv_U;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_U1:
                {
                    return OpCodes.Conv_U1;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_U2:
                {
                    return OpCodes.Conv_U2;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_U4:
                {
                    return OpCodes.Conv_U4;

                }
                case Libs.Mono.Cecil.Cil.Code.Conv_U8:
                {
                    return OpCodes.Conv_U8;

                }
                case Libs.Mono.Cecil.Cil.Code.Cpblk:
                {
                    return OpCodes.Cpblk;

                }
                case Libs.Mono.Cecil.Cil.Code.Cpobj:
                {
                    return OpCodes.Cpobj;
                }
                case Libs.Mono.Cecil.Cil.Code.Div:
                {
                    return OpCodes.Div;

                }
                case Libs.Mono.Cecil.Cil.Code.Div_Un:
                {
                    return OpCodes.Div_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Dup:
                {
                    return OpCodes.Dup;

                }
                case Libs.Mono.Cecil.Cil.Code.Endfilter:
                {

                    return OpCodes.Endfilter;

                }
                case Libs.Mono.Cecil.Cil.Code.Endfinally:
                {
                    return OpCodes.Endfinally;
                }
                case Libs.Mono.Cecil.Cil.Code.Initblk:
                {
                    return OpCodes.Initblk;

                }
                case Libs.Mono.Cecil.Cil.Code.Initobj:
                {
                    return OpCodes.Initobj;


                }
                case Libs.Mono.Cecil.Cil.Code.Isinst:
                {
                    return OpCodes.Isinst;
                }
                case Libs.Mono.Cecil.Cil.Code.Jmp:
                {
                    return OpCodes.Jmp;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarg:
                {
                    return OpCodes.Ldarg;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarga:
                {
                    return OpCodes.Ldarga;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarga_S:
                {
                    return OpCodes.Ldarga_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarg_0:
                {
                    return OpCodes.Ldarg_0;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarg_1:
                {
                    return OpCodes.Ldarg_1;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldarg_2:
                {
                    return OpCodes.Ldarg_2;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldarg_3:
                {
                    return OpCodes.Ldarg_3;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldarg_S:
                {
                    return OpCodes.Ldarg_S;


                }
                // Constant Loading - Push the supplied integer value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4:
                {
                    return OpCodes.Ldc_I4;
                }
                // Constant Loading - Push the supplied integer value of 0 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_0:
                {
                    return OpCodes.Ldc_I4_0;

                }
                // Constant Loading - Push the supplied integer value of 1 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_1:
                {
                    return OpCodes.Ldc_I4_1;

                }
                // Constant Loading - Push the supplied integer value of 2 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_2:
                {
                    return OpCodes.Ldc_I4_2;

                }
                // Constant Loading - Push the supplied integer value of 3 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_3:
                {
                    return OpCodes.Ldc_I4_3;

                }
                // Constant Loading - Push the supplied integer value of 4 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_4:
                {
                    return OpCodes.Ldc_I4_4;

                }
                // Constant Loading - Push the supplied integer value of 5 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_5:
                {
                    return OpCodes.Ldc_I4_5;

                }
                // Constant Loading - Push the supplied integer value of 6 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_6:
                {
                    return OpCodes.Ldc_I4_6;

                }
                // Constant Loading - Push the supplied integer value of 7 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_7:
                {
                    return OpCodes.Ldc_I4_7;

                }
                // Constant Loading - Push the supplied integer value of 8 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_8:
                {
                    return OpCodes.Ldc_I4_8;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_M1:
                {
                    return OpCodes.Ldc_I4_M1;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_S:
                {
                    return OpCodes.Ldc_I4_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_I8:
                {
                    return OpCodes.Ldc_I8;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_R4:
                {
                    return OpCodes.Ldc_R4;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_R8:
                {
                    return OpCodes.Ldc_R8;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldnull:
                {
                    return OpCodes.Ldnull;

                }
                case Libs.Mono.Cecil.Cil.Code.Leave:
                {
                    return OpCodes.Leave;


                }
                case Libs.Mono.Cecil.Cil.Code.Leave_S:
                {
                    return OpCodes.Leave_S;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldelema:
                {

                    return OpCodes.Ldelema;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_Any:
                {
                    return OpCodes.Ldelem;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I:
                {
                    return OpCodes.Ldelem_I;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I1:
                {
                    return OpCodes.Ldelem_I1;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I2:
                {
                    return OpCodes.Ldelem_I2;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I4:
                {
                    return OpCodes.Ldelem_I4;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I8:
                {
                    return OpCodes.Ldelem_I8;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_R4:
                {
                    return OpCodes.Ldelem_R4;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_R8:
                {
                    return OpCodes.Ldelem_R8;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_Ref:
                {
                    return OpCodes.Ldelem_Ref;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_U1:
                {
                    return OpCodes.Ldelem_U1;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_U2:
                {
                    return OpCodes.Ldelem_U2;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_U4:
                {
                    return OpCodes.Ldelem_U4;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldfld:
                {
                    return OpCodes.Ldfld;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldflda:
                {
                    return OpCodes.Ldflda;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldftn:
                {
                    return OpCodes.Ldftn;
                }

                case Libs.Mono.Cecil.Cil.Code.Ldlen:
                {
                    return OpCodes.Ldlen;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_I:
                {
                    return OpCodes.Ldind_I;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_I1:
                {
                    return OpCodes.Ldind_I1;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_I2:
                {
                    return OpCodes.Ldind_I2;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_I4:
                {
                    return OpCodes.Ldind_I4;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_I8:
                {
                    return OpCodes.Ldind_I8;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_R4:
                {
                    return OpCodes.Ldind_R4;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_R8:
                {
                    return OpCodes.Ldind_R8;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_Ref:
                {
                    return OpCodes.Ldind_Ref;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_U1:
                {
                    return OpCodes.Ldind_U1;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_U2:
                {
                    return OpCodes.Ldind_U2;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_U4:
                {
                    return OpCodes.Ldind_U4;

                }
                // Local Load - Push the local value at the location specified by the supplied short value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc:
                {
                    return OpCodes.Ldloc;
                }
                // Local Load - Push the address of the local value at the location specified by the supplied short value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloca:
                {
                    return OpCodes.Ldloca;


                }
                // Local Load - Push the address of the local value at the location specified by the supplied byte value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloca_S:
                {
                    return OpCodes.Ldloca_S;
                }
                // Local Load - Push the local value 0 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc_0:
                {
                    return OpCodes.Ldloc_0;

                }
                // Local Load - Push the local value 0 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc_1:
                {
                    return OpCodes.Ldloc_1;

                }
                // Local Load - Push the local value 0 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc_2:
                {
                    return OpCodes.Ldloc_2;

                }
                // Local Load - Push the local value 0 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc_3:
                {
                    return OpCodes.Ldloc_3;

                }
                // Local Load - Push the local value at the location specified by the supplied byte value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc_S:
                {
                    return OpCodes.Ldloc_S;



                }
                case Libs.Mono.Cecil.Cil.Code.Ldobj:
                {


                    return OpCodes.Ldobj;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldsfld:
                {


                    return OpCodes.Ldsfld;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldsflda:
                {
                    return OpCodes.Ldsflda;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldstr:
                {
                    return OpCodes.Ldstr;

                }
                case Libs.Mono.Cecil.Cil.Code.Ldtoken:
                {



                    return OpCodes.Ldtoken;


                }
                case Libs.Mono.Cecil.Cil.Code.Ldvirtftn:
                {


                    return OpCodes.Ldvirtftn;


                }
                case Libs.Mono.Cecil.Cil.Code.Localloc:
                {
                    return OpCodes.Localloc;

                }
                case Libs.Mono.Cecil.Cil.Code.Mkrefany:
                {


                    return OpCodes.Mkrefany;


                }
                case Libs.Mono.Cecil.Cil.Code.Mul:
                {
                    return OpCodes.Mul;

                }
                case Libs.Mono.Cecil.Cil.Code.Mul_Ovf:
                {
                    return OpCodes.Mul_Ovf;

                }
                case Libs.Mono.Cecil.Cil.Code.Mul_Ovf_Un:
                {
                    return OpCodes.Mul_Ovf_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Neg:
                {
                    return OpCodes.Neg;

                }
                case Libs.Mono.Cecil.Cil.Code.Newarr:
                {


                    return OpCodes.Newarr;


                }
                case Libs.Mono.Cecil.Cil.Code.Newobj:
                {
                    return OpCodes.Newobj;



                }
                case Libs.Mono.Cecil.Cil.Code.Nop:
                {
                    return OpCodes.Nop;

                }
                case Libs.Mono.Cecil.Cil.Code.Not:
                {
                    return OpCodes.Not;

                }
                case Libs.Mono.Cecil.Cil.Code.Pop:
                {
                    return OpCodes.Pop;

                }
                case Libs.Mono.Cecil.Cil.Code.Or:
                {
                    return OpCodes.Or;

                }

                case Libs.Mono.Cecil.Cil.Code.Readonly:
                {
                    return OpCodes.Readonly;

                }
                case Libs.Mono.Cecil.Cil.Code.Refanytype:
                {
                    return OpCodes.Refanytype;

                }
                case Libs.Mono.Cecil.Cil.Code.Refanyval:
                {


                    return OpCodes.Refanyval;


                }
                case Libs.Mono.Cecil.Cil.Code.Rem:
                {
                    return OpCodes.Rem;

                }
                case Libs.Mono.Cecil.Cil.Code.Rem_Un:
                {
                    return OpCodes.Rem_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Ret:
                {
                    return OpCodes.Ret;

                }
                case Libs.Mono.Cecil.Cil.Code.Rethrow:
                {
                    return OpCodes.Rethrow;

                }
                case Libs.Mono.Cecil.Cil.Code.Sizeof:
                {
                    return OpCodes.Sizeof;
                }
                case Libs.Mono.Cecil.Cil.Code.Starg:
                {
                    return OpCodes.Starg_S;

                }
                case Libs.Mono.Cecil.Cil.Code.Starg_S:
                {
                    return OpCodes.Starg_S;
                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_Any:
                {
                    return OpCodes.Stelem;

                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_I:
                {
                    return OpCodes.Stelem_I;

                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_I1:
                {
                    return OpCodes.Stelem_I1;

                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_I2:
                {
                    return OpCodes.Stelem_I2;

                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_I4:
                {
                    return OpCodes.Stelem_I4;

                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_I8:
                {
                    return OpCodes.Stelem_I8;

                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_R4:
                {
                    return OpCodes.Stelem_R4;

                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_R8:
                {
                    return OpCodes.Stelem_R8;

                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_Ref:
                {
                    return OpCodes.Stelem_Ref;

                }
                case Libs.Mono.Cecil.Cil.Code.Stfld:
                {


                    return OpCodes.Stfld;


                }
                case Libs.Mono.Cecil.Cil.Code.Stsfld:
                {


                    return OpCodes.Stsfld;


                }
                case Libs.Mono.Cecil.Cil.Code.Stind_I:
                {
                    return OpCodes.Stind_I;

                }
                case Libs.Mono.Cecil.Cil.Code.Stind_I1:
                {
                    return OpCodes.Stind_I1;

                }
                case Libs.Mono.Cecil.Cil.Code.Stind_I2:
                {
                    return OpCodes.Stind_I2;

                }
                case Libs.Mono.Cecil.Cil.Code.Stind_I4:
                {
                    return OpCodes.Stind_I4;

                }
                case Libs.Mono.Cecil.Cil.Code.Stind_I8:
                {
                    return OpCodes.Stind_I8;

                }
                case Libs.Mono.Cecil.Cil.Code.Stind_R4:
                {
                    return OpCodes.Stind_R4;

                }
                case Libs.Mono.Cecil.Cil.Code.Stind_R8:
                {
                    return OpCodes.Stind_R8;

                }
                case Libs.Mono.Cecil.Cil.Code.Stind_Ref:
                {
                    return OpCodes.Stind_Ref;

                }

                case Libs.Mono.Cecil.Cil.Code.Stloc:
                {
                    return OpCodes.Stloc;
                }
                // Local Store - Pops the value on the stack and stores it in local 0
                case Libs.Mono.Cecil.Cil.Code.Stloc_0:
                {
                    return OpCodes.Stloc_0;

                }
                // Local Store - Pops the value on the stack and stores it in local 1
                case Libs.Mono.Cecil.Cil.Code.Stloc_1:
                {
                    return OpCodes.Stloc_1;

                }
                // Local Store - Pops the value on the stack and stores it in local 2
                case Libs.Mono.Cecil.Cil.Code.Stloc_2:
                {
                    return OpCodes.Stloc_2;

                }
                // Local Store - Pops the value on the stack and stores it in local 3
                case Libs.Mono.Cecil.Cil.Code.Stloc_3:
                {
                    return OpCodes.Stloc_3;

                }
                // Local Store - Pops the value on the stack and stores it in local location specified by the supplied byte value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Stloc_S:
                {
                    return OpCodes.Stloc_S;



                }
                case Libs.Mono.Cecil.Cil.Code.Shl:
                {
                    return OpCodes.Shl;

                }
                case Libs.Mono.Cecil.Cil.Code.Shr:
                {
                    return OpCodes.Shr;

                }
                case Libs.Mono.Cecil.Cil.Code.Shr_Un:
                {
                    return OpCodes.Shr_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Stobj:
                {


                    return OpCodes.Stobj;


                }
                case Libs.Mono.Cecil.Cil.Code.Sub:
                {
                    return OpCodes.Sub;

                }
                case Libs.Mono.Cecil.Cil.Code.Sub_Ovf:
                {
                    return OpCodes.Sub_Ovf;

                }
                case Libs.Mono.Cecil.Cil.Code.Sub_Ovf_Un:
                {
                    return OpCodes.Sub_Ovf_Un;

                }
                case Libs.Mono.Cecil.Cil.Code.Switch:
                {


                    return OpCodes.Switch;


                }
                case Libs.Mono.Cecil.Cil.Code.Tail:
                {
                    return OpCodes.Tailcall;


                }
                case Libs.Mono.Cecil.Cil.Code.Throw:
                {
                    return OpCodes.Throw;


                }
                case Libs.Mono.Cecil.Cil.Code.Unaligned:
                {

                    return OpCodes.Unaligned;


                }
                case Libs.Mono.Cecil.Cil.Code.Unbox:
                {


                    return OpCodes.Unbox;


                }
                case Libs.Mono.Cecil.Cil.Code.Unbox_Any:
                {


                    return OpCodes.Unbox_Any;


                }
                case Libs.Mono.Cecil.Cil.Code.Volatile:
                {
                    return OpCodes.Volatile;

                }
                case Libs.Mono.Cecil.Cil.Code.Xor:
                {
                    return OpCodes.Xor;

                }
                default:
                {
                    //No = 214,
                    throw new System.Exception($"Code {opCodeCode.ToString()} not handled.");
                }
            }
        }
    }
}
