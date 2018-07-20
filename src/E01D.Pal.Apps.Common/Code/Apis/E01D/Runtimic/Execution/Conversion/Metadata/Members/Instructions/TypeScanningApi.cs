using System;
using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Cil;
using Root.Code.Libs.Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions
{
    public class TypeScanningApi<TContainer> : ConversionApiNode<TContainer>, TypeScanningApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public void EnsureTypes(ILConversion conversion, Collection<Instruction> instructions)
	    {
		    EnsureTypes(conversion, null, null, instructions);

		    throw new Exception("Not currently supported");
	    }


		public void EnsureTypes(ILConversion conversion, ConvertedTypeDefinition_I converted, MethodDefinition callingMethodDefinition, Collection<Instruction> instructions)
        {
            for (int i = 0; i < instructions.Count; i++)
            {
                var instructionDefinition = instructions[i];


	            switch (instructionDefinition.OpCode.Code)
	            {
		            case Libs.Mono.Cecil.Cil.Code.Add:
		            case Libs.Mono.Cecil.Cil.Code.Add_Ovf:
		            case Libs.Mono.Cecil.Cil.Code.Add_Ovf_Un:
		            case Libs.Mono.Cecil.Cil.Code.And:
		            case Libs.Mono.Cecil.Cil.Code.Arglist:
		            case Libs.Mono.Cecil.Cil.Code.Beq:
		            case Libs.Mono.Cecil.Cil.Code.Beq_S:
		            case Libs.Mono.Cecil.Cil.Code.Bge:
		            case Libs.Mono.Cecil.Cil.Code.Bge_S:
		            case Libs.Mono.Cecil.Cil.Code.Bge_Un:
		            case Libs.Mono.Cecil.Cil.Code.Bge_Un_S:
		            case Libs.Mono.Cecil.Cil.Code.Bgt:
		            case Libs.Mono.Cecil.Cil.Code.Bgt_S:
		            case Libs.Mono.Cecil.Cil.Code.Bgt_Un:
		            case Libs.Mono.Cecil.Cil.Code.Bgt_Un_S:
		            case Libs.Mono.Cecil.Cil.Code.Ble:
		            case Libs.Mono.Cecil.Cil.Code.Ble_S:
		            case Libs.Mono.Cecil.Cil.Code.Ble_Un:
		            case Libs.Mono.Cecil.Cil.Code.Ble_Un_S:
		            case Libs.Mono.Cecil.Cil.Code.Blt:
		            case Libs.Mono.Cecil.Cil.Code.Blt_S:
		            case Libs.Mono.Cecil.Cil.Code.Blt_Un:
		            case Libs.Mono.Cecil.Cil.Code.Blt_Un_S:
		            case Libs.Mono.Cecil.Cil.Code.Bne_Un:
		            case Libs.Mono.Cecil.Cil.Code.Bne_Un_S:
		            // Unconditional Branching - Long Form
		            case Libs.Mono.Cecil.Cil.Code.Br:
		            // Inserts an breakpoint into the IL stream - takes no parameters; does not touch the evaluation stack
		            case Libs.Mono.Cecil.Cil.Code.Break:
		            // Conditional Branching - Pop a value from evaluation stack and see if it is 0.  If so, branch.
		            case Libs.Mono.Cecil.Cil.Code.Brfalse:
		            // Conditional Branching - Pop a value from evaluation stack and see if it is 0.  If so, branch.
		            case Libs.Mono.Cecil.Cil.Code.Brfalse_S:
		            // Conditional Branching - Pop a value from evaluation stack and see if it is 1.  If so, branch.
		            case Libs.Mono.Cecil.Cil.Code.Brtrue:
		            // Conditional Branching - Pop a value from evaluation stack and see if it is 1.  If so, branch.
		            case Libs.Mono.Cecil.Cil.Code.Brtrue_S:
		            // Unconditional Branching - Short Form
		            case Libs.Mono.Cecil.Cil.Code.Br_S:

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
		            case Libs.Mono.Cecil.Cil.Code.Ldarg:
		            case Libs.Mono.Cecil.Cil.Code.Ldarga:
		            case Libs.Mono.Cecil.Cil.Code.Ldarga_S:

		            case Libs.Mono.Cecil.Cil.Code.Ldarg_0:
		            case Libs.Mono.Cecil.Cil.Code.Ldarg_1:
		            case Libs.Mono.Cecil.Cil.Code.Ldarg_2:
		            case Libs.Mono.Cecil.Cil.Code.Ldarg_3:
		            case Libs.Mono.Cecil.Cil.Code.Ldarg_S:
		            // Constant Loading - Push the supplied integer value onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I4:
		            // Constant Loading - Push the supplied integer value of 0 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I4_0:
		            // Constant Loading - Push the supplied integer value of 1 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I4_1:
		            // Constant Loading - Push the supplied integer value of 2 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I4_2:
		            // Constant Loading - Push the supplied integer value of 3 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I4_3:
		            // Constant Loading - Push the supplied integer value of 4 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I4_4:
		            // Constant Loading - Push the supplied integer value of 5 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I4_5:
		            // Constant Loading - Push the supplied integer value of 6 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I4_6:
		            // Constant Loading - Push the supplied integer value of 7 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I4_7:
		            // Constant Loading - Push the supplied integer value of 8 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I4_8:
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I4_M1:
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I4_S:
		            case Libs.Mono.Cecil.Cil.Code.Ldc_I8:
		            case Libs.Mono.Cecil.Cil.Code.Ldc_R4:
		            case Libs.Mono.Cecil.Cil.Code.Ldc_R8:
		            case Libs.Mono.Cecil.Cil.Code.Leave:

		            case Libs.Mono.Cecil.Cil.Code.Leave_S:
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
		            //case Mono.Cecil.Cil.Code.Ldfld:
		            //case Mono.Cecil.Cil.Code.Ldflda:
		            //case Mono.Cecil.Cil.Code.Ldftn:
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
		            // Local Load - Push the local value at the location specified by the supplied short value onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldloc:
		            // Local Load - Push the address of the local value at the location specified by the supplied short value onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldloca:
		            // Local Load - Push the address of the local value at the location specified by the supplied byte value onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldloca_S:
		            // Local Load - Push the local value 0 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldloc_0:
		            // Local Load - Push the local value 0 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldloc_1:
		            // Local Load - Push the local value 0 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldloc_2:
		            // Local Load - Push the local value 0 onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldloc_3:
		            // Local Load - Push the local value at the location specified by the supplied byte value onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Ldloc_S:
		            case Libs.Mono.Cecil.Cil.Code.Ldnull:
		            //case Mono.Cecil.Cil.Code.Ldsfld:
		            //case Mono.Cecil.Cil.Code.Ldsflda:
		            case Libs.Mono.Cecil.Cil.Code.Ldstr:
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
					case Libs.Mono.Cecil.Cil.Code.Starg:
		            case Libs.Mono.Cecil.Cil.Code.Starg_S:
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
		            // Local Store - Pops the value on the stack and stores it in local location specified by the supplied short value onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Stloc:
		            // Local Store - Pops the value on the stack and stores it in local 0
		            case Libs.Mono.Cecil.Cil.Code.Stloc_0:
		            // Local Store - Pops the value on the stack and stores it in local 1
		            case Libs.Mono.Cecil.Cil.Code.Stloc_1:
		            // Local Store - Pops the value on the stack and stores it in local 2
		            case Libs.Mono.Cecil.Cil.Code.Stloc_2:
		            // Local Store - Pops the value on the stack and stores it in local 3
		            case Libs.Mono.Cecil.Cil.Code.Stloc_3:
		            // Local Store - Pops the value on the stack and stores it in local location specified by the supplied byte value onto the stack
		            case Libs.Mono.Cecil.Cil.Code.Stloc_S:
		            case Libs.Mono.Cecil.Cil.Code.Shl:
		            case Libs.Mono.Cecil.Cil.Code.Shr:
		            case Libs.Mono.Cecil.Cil.Code.Shr_Un:
		            case Libs.Mono.Cecil.Cil.Code.Sub:
		            case Libs.Mono.Cecil.Cil.Code.Sub_Ovf:
		            case Libs.Mono.Cecil.Cil.Code.Sub_Ovf_Un:
		            case Libs.Mono.Cecil.Cil.Code.Switch:
					case Libs.Mono.Cecil.Cil.Code.Tail:
		            case Libs.Mono.Cecil.Cil.Code.Throw:
		            case Libs.Mono.Cecil.Cil.Code.Unaligned:
					case Libs.Mono.Cecil.Cil.Code.Volatile:
		            case Libs.Mono.Cecil.Cil.Code.Xor:
		            {
			            break;
		            }
		            default:
		            {
			            SemanticTypeDefinitionMask_I ensuredType = null;

			            TypeReference typeReferenceToLookup = null;

			            if (instructionDefinition.Operand is TypeReference typeReference)
			            {
				            //ensuredType = Types.Scanning.EnsureType(conversion, typeReference);
			            }
			            else if (instructionDefinition.Operand is FieldReference fieldReference)
			            {
				            //ensuredType = Types.Scanning.EnsureType(conversion, fieldReference.DeclaringType);
			            }
			            else if (instructionDefinition.Operand is MethodReference methodReference)
			            {
								//if (methodReference is Mono.Cecil.GenericInstanceMethod genericMethodReference)
								//{
								// for (int j = 0; j < genericMethodReference.GenericArguments.Count; j++)
								// {
								//  var genericArgument = genericMethodReference.GenericArguments[j];

								//  Types.Scanning.EnsureType(conversion, genericArgument);
								// }
								//}

				            //var resolvedMethodReference = Cecil.Metadata.Members.Methods.ResolveSignatureReferenceToFullReference(conversion.Model, converted.SourceTypeReference, callingMethodDefinition, methodReference);

				            //typeReferenceToLookup = resolvedMethodReference.DeclaringType;

								
			            }
						else if (instructionDefinition.Operand is MemberReference memberReference)
			            {
							//ensuredType = Types.Scanning.EnsureType(conversion, memberReference.DeclaringType);
						}
			            else
			            {
				            throw new Exception("Instruction type scanning not handled.");
			            }

			            if (typeReferenceToLookup != null)
			            {
				            if (typeReferenceToLookup.IsGenericInstance && converted.SourceTypeReference.IsGenericInstance)
				            {
					            if (typeReferenceToLookup.FullName == "System.Collections.Generic.List`1<TOutput>")
					            {
						            
					            }

					            var genericTypeReferenceToLookup = (GenericInstanceType) typeReferenceToLookup;

					            var genericConverted = (GenericInstanceType)converted.SourceTypeReference;

								if (Cecil.Types.AreSame(genericTypeReferenceToLookup.ElementType, genericConverted.ElementType))
								{
									break;
								}

				            }

							

							ensuredType = Types.Scanning.EnsureType(conversion, typeReferenceToLookup);

				            if (ensuredType != null
				                && ensuredType is ConvertedTypeDefinition_I convertedInstructionReference
				                // do not add if the instruction type is itself
				                && !ReferenceEquals(convertedInstructionReference, converted)
				                // do not add if the instruction type's blueprint is itself
				                && !(convertedInstructionReference is ConvertedGenericTypeDefinition_I genericInstructionType
				                     && ReferenceEquals(converted, genericInstructionType.Blueprint))
				                && convertedInstructionReference.ConversionState.BuildPhase != Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.BuildPhaseKind.TypeCreated)
				            {


					            AddDependentOrDependency(convertedInstructionReference.ConversionState.Phase3Dependents, converted);

					            AddDependentOrDependency(converted.ConversionState.Phase3Dependencies, convertedInstructionReference);


				            }
							}

			           

			            break;

		            }
	            }
            }
        }

	    public void AddDependentOrDependency(Dictionary<string, ConvertedTypeDefinition_I> dictionary, ConvertedTypeDefinition_I converted)
	    {
			
		    if (!dictionary.ContainsKey(converted.ResolutionName))
		    {
			    dictionary.Add(converted.ResolutionName, converted);
		    }
	    }
	}
}
