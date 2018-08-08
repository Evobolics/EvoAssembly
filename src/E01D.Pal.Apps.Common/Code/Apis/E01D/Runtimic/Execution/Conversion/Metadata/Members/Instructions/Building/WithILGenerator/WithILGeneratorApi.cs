using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Cil;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithILGenerator
{
    public class WithILGeneratorApi<TContainer> : ConversionApiNode<TContainer>, WithILGeneratorApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        // When set to true, it surpresses the IL output of the following opcodes in the IL stream in favor of using ILGenerator built in commands
        // EndFilter
        // End
        // Leave
        // Leave.S
        public const bool UseILGeneratorExceptionHandling = false;

        public ExceptionHandlingApi_I<TContainer> ExceptionHandling { get; set; }

        public LabelingApi_I<TContainer> Labeling { get; set; }

        public bool GenerateIL(ILConversion conversion, ConvertedTypeDefinition_I convertedType)
        {
            var noDependenciesFound = true;

            // Done on purpose to find errors
            var typeDefinition = (TypeDefinition)convertedType.SourceTypeReference;

            if (!typeDefinition.HasMethods) return true;

            if (convertedType is ConvertedTypeWithConstructors_I convertedTypeWithConstructors)
            {
                noDependenciesFound &= BuildConstructorInstructions(conversion, convertedType, convertedTypeWithConstructors.Constructors);
            }

            if (convertedType is ConvertedTypeWithMethods_I convertedTypeWithMethods)
            {
                noDependenciesFound &= BuildMethodInstructions(conversion, convertedType, convertedTypeWithMethods.Methods);
            }

            return noDependenciesFound;
        }

        private bool BuildConstructorInstructions(ILConversion conversion, ConvertedTypeDefinition_I input, ConvertedTypeDefinitionConstructors constructors)
        {
            bool noDependenciesFound = true;

            foreach (var constructorEntry in constructors.All)
            {
                if (!(constructorEntry is ConvertedEmittedConstructor convertedConstructor))
                {
                    throw new Exception("Expected a converted constructor to build.");
                }

                var methodReference = constructorEntry.MethodReference;

                if (!methodReference.IsDefinition) continue;

                var methodDefinition = (MethodDefinition)methodReference;

                if (methodDefinition.Body == null) continue;

                if (convertedConstructor.IlGenerator == null) // can be null if this is tried a second time.
                {
                    convertedConstructor.IlGenerator = convertedConstructor.ConstructorBuilder.GetILGenerator();
                }

                noDependenciesFound &= GenerateIL(conversion, input, convertedConstructor);
            }

            return noDependenciesFound;
        }

        private bool BuildMethodInstructions(ILConversion conversion, ConvertedTypeDefinition_I input, ConvertedTypeDefinitionMethods methods)
        {
            bool noDependenciesFound = true;

            foreach (var methodList in methods.ByName.Values)
            {
                foreach (var methodEntry in methodList)
                {
                    if (!(methodEntry is ConvertedBuiltMethod convertedMethod))
                    {
                        throw new Exception("Expected a converted method to build.");
                    }

                    var methodReference = methodEntry.MethodReference;

                    if (!methodReference.IsDefinition) continue;

                    var methodDefinition = (MethodDefinition)methodReference;

                    if (methodDefinition.Body == null) continue;

                    var methodBuilder = convertedMethod.MethodBuilder;




                    if (convertedMethod.IlGenerator == null) // can be null if this is tried a second time.
                    {
                        convertedMethod.IlGenerator = methodBuilder.GetILGenerator();
                    }

                    noDependenciesFound &= GenerateIL(conversion, input, convertedMethod);
                }

            }

            return noDependenciesFound;

        }

        public bool GenerateIL(ILConversion conversion, ConvertedTypeDefinition_I typeBeingBuilt, ConvertedRoutine routine)
        {
            if (routine.ILFullyEmitted) return true;

            if (!routine.MethodReference.IsDefinition) return true;

            if (ScanILForBranchesAndTypes(conversion, typeBeingBuilt, routine))
            {
                return false;
            }

            routine.ILFullyEmitted = true;

            DeclareLocalVariables(conversion, routine);

            if (typeBeingBuilt.FullName ==
                "Root.Code.Apis.E01D.Activation.CommonAppActivationDomainApi"
                && routine.MethodReference.FullName == "System.Object Root.Code.Apis.E01D.Activation.CommonAppActivationDomainApi::CreateInstance(System.Type)"
            )
            {



            }

#pragma warning disable 162
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse	
            if (UseILGeneratorExceptionHandling)
            {
                ExceptionHandling.Preprocess(conversion, routine);
            }
#pragma warning restore 162

            var methodDefinition = (MethodDefinition)routine.MethodReference;



            for (int iInstruction = 0; iInstruction < methodDefinition.Body.Instructions.Count; iInstruction++)
            {
                var instructionDefinition = methodDefinition.Body.Instructions[iInstruction];

                MarkLabelIfInstructionIsBranchTarget(routine, instructionDefinition);

#pragma warning disable 162
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse	
                if (UseILGeneratorExceptionHandling)
                {
                    ExceptionHandling.ProcessInstruction(conversion, routine, instructionDefinition);
                }
#pragma warning restore 162

                EmitInstruction(conversion, typeBeingBuilt, routine, instructionDefinition);
            }



            return true;
        }

        private void MarkLabelIfInstructionIsBranchTarget(ConvertedRoutine routine, Instruction instructionDefinition)
        {
            var ilGenerator = routine.IlGenerator;

            var labelEntries = routine.LabelEntries;

            if (labelEntries.TryGetValue(instructionDefinition.Offset, out ConvertedLabel currentLabelEntry))
            {
                ilGenerator.MarkLabel(currentLabelEntry.Label);
            }
        }

        private void EmitInstruction(ILConversion conversion, ConvertedTypeDefinition_I typeBeingBuilt, ConvertedRoutine routine, Instruction instructionDefinition)
        {
            /*
			 * There seems to be a possible bug with the instruciton emit code.
			 */



            var ilGenerator = routine.IlGenerator;

            var labelEntries = routine.LabelEntries;

            var switchEntries = routine.SwitchEntries;

            if (typeBeingBuilt.FullName ==
                "Root.Code.Apis.E01D.Activation.CommonAppActivationDomainApi"
                //&& routine.MethodReference.FullName == "System.Type Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Assemblies.AssemblyDomainApi::GetTypeInAssembly(System.Type[],System.Type)"
            )
            {
                if (ilGenerator.ILOffset != instructionDefinition.Offset)
                {
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (!UseILGeneratorExceptionHandling)
                    {
                        throw new Exception("Offset mismatch");
                    }
#pragma warning restore 162
                }


            }

            //https://groups.google.com/forum/#!topic/mono-cecil/soyOb3tLKPQ
            //Calli = 40,
            //Switch = 68,
            System.Reflection.Emit.OpCode opCode = Cecil.Metadata.Instructions.ConvertOpCode(instructionDefinition.OpCode.Code);

            switch (instructionDefinition.OpCode.Code)
            {
                case Libs.Mono.Cecil.Cil.Code.Add:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Add);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Add_Ovf:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Add_Ovf);
                    break;
                }

                case Libs.Mono.Cecil.Cil.Code.Add_Ovf_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Add_Ovf_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.And:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.And);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Arglist:
                {
                    //https://msdn.microsoft.com/en-us/library/system.reflection.emit.opcodes.arglist(v=vs.110).aspx

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Arglist);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Beq:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Beq, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Beq_S:
                {
                    // If the we use the ILGenerator to build instructions, then it always uses the leave instruction and not the leave_s.  This can
                    // cause offsets between branch instructions and their target to be greater than 128 bytes or less than -127 bytes.  The result
                    // is an invalid instruction.  To prevent this, the larger branching instruciton must be used.
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse	
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Beq_S, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Beq, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Bge:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bge, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Bge_S:
                {
                    // If the we use the ILGenerator to build instructions, then it always uses the leave instruction and not the leave_s.  This can
                    // cause offsets between branch instructions and their target to be greater than 128 bytes or less than -127 bytes.  The result
                    // is an invalid instruction.  To prevent this, the larger branching instruciton must be used.
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse	
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bge_S, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bge, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Bge_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bge_Un, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Bge_Un_S:
                {
                    // If the we use the ILGenerator to build instructions, then it always uses the leave instruction and not the leave_s.  This can
                    // cause offsets between branch instructions and their target to be greater than 128 bytes or less than -127 bytes.  The result
                    // is an invalid instruction.  To prevent this, the larger branching instruciton must be used.
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse	
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bge_Un_S, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bge_Un, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Bgt:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bgt, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Bgt_S:
                {
                    // If the we use the ILGenerator to build instructions, then it always uses the leave instruction and not the leave_s.  This can
                    // cause offsets between branch instructions and their target to be greater than 128 bytes or less than -127 bytes.  The result
                    // is an invalid instruction.  To prevent this, the larger branching instruciton must be used.
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse	
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bgt_S, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bgt, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Bgt_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bgt_Un, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Bgt_Un_S:
                {
                    // If the we use the ILGenerator to build instructions, then it always uses the leave instruction and not the leave_s.  This can
                    // cause offsets between branch instructions and their target to be greater than 128 bytes or less than -127 bytes.  The result
                    // is an invalid instruction.  To prevent this, the larger branching instruciton must be used.
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse	
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bgt_Un_S, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bgt_Un, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ble:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ble, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ble_S:
                {
                    // If the we use the ILGenerator to build instructions, then it always uses the leave instruction and not the leave_s.  This can
                    // cause offsets between branch instructions and their target to be greater than 128 bytes or less than -127 bytes.  The result
                    // is an invalid instruction.  To prevent this, the larger branching instruciton must be used.
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse	
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ble_S, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ble, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
#pragma warning restore 162
                    break;
                }

                case Libs.Mono.Cecil.Cil.Code.Ble_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ble_Un, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ble_Un_S:
                {
                    // If the we use the ILGenerator to build instructions, then it always uses the leave instruction and not the leave_s.  This can
                    // cause offsets between branch instructions and their target to be greater than 128 bytes or less than -127 bytes.  The result
                    // is an invalid instruction.  To prevent this, the larger branching instruciton must be used.
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse	
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ble_Un_S, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ble_Un, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Blt:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Blt, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Blt_S:
                {
                    // If the we use the ILGenerator to build instructions, then it always uses the leave instruction and not the leave_s.  This can
                    // cause offsets between branch instructions and their target to be greater than 128 bytes or less than -127 bytes.  The result
                    // is an invalid instruction.  To prevent this, the larger branching instruciton must be used.
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Blt_S, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Blt, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Blt_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Blt_Un, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Blt_Un_S:
                {
                    // If the we use the ILGenerator to build instructions, then it always uses the leave instruction and not the leave_s.  This can
                    // cause offsets between branch instructions and their target to be greater than 128 bytes or less than -127 bytes.  The result
                    // is an invalid instruction.  To prevent this, the larger branching instruciton must be used.
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Blt_Un_S, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Blt_Un, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Bne_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bne_Un, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Bne_Un_S:
                {
                    // If the we use the ILGenerator to build instructions, then it always uses the leave instruction and not the leave_s.  This can
                    // cause offsets between branch instructions and their target to be greater than 128 bytes or less than -127 bytes.  The result
                    // is an invalid instruction.  To prevent this, the larger branching instruciton must be used.
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bne_Un_S, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Bne_Un, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Box:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Box, declaringType);

                    break;
                }

                // Unconditional Branching - Long Form
                case Libs.Mono.Cecil.Cil.Code.Br:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Br, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                // Inserts an breakpoint into the IL stream - takes no parameters; does not touch the evaluation stack
                case Libs.Mono.Cecil.Cil.Code.Break:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Break);

                    break;
                }
                // Conditional Branching - Pop a value from evaluation stack and see if it is 0.  If so, branch.
                case Libs.Mono.Cecil.Cil.Code.Brfalse:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Brfalse, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                // Conditional Branching - Pop a value from evaluation stack and see if it is 0.  If so, branch.
                case Libs.Mono.Cecil.Cil.Code.Brfalse_S:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Brfalse_S, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }

                // Conditional Branching - Pop a value from evaluation stack and see if it is 1.  If so, branch.
                case Libs.Mono.Cecil.Cil.Code.Brtrue:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Brtrue, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                // Conditional Branching - Pop a value from evaluation stack and see if it is 1.  If so, branch.
                case Libs.Mono.Cecil.Cil.Code.Brtrue_S:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Brtrue_S, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }
                // Unconditional Branching - Short Form
                case Libs.Mono.Cecil.Cil.Code.Br_S:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Br_S, Labeling.GetLabel(labelEntries, instructionDefinition));

                    break;
                }

                case Libs.Mono.Cecil.Cil.Code.Call:
                case Libs.Mono.Cecil.Cil.Code.Callvirt:
                {
                    var methodReference = (MethodReference)instructionDefinition.Operand;

                    var declaringBound = Execution.Types.Ensuring.EnsureBound(conversion, methodReference.DeclaringType);

                    if ((declaringBound is ConvertedTypeDefinition_I convertedType)
                        && Types.Building.CheckForPhase3Dependency(convertedType, (ConvertedTypeDefinition_I)routine.DeclaringType, true))
                    {
                        throw new Exception("Could not find member.  Need to gracefully exit and comeback.");
                    }

                    if (!Members.GetMemberInfo(conversion, routine.DeclaringType, routine, declaringBound, methodReference,
                        out MemberInfo memberInfo))
                    {
                        throw new Exception("Could not find member.  Need to gracefully exit and comeback.");
                    }

                    if (memberInfo is ConstructorInfo constructor)
                    {
                        ilGenerator.Emit(opCode, constructor);
                    }
                    else if (memberInfo is MethodInfo methodInfo)
                    {
                        ilGenerator.Emit(opCode, methodInfo);
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
                
                
                case Libs.Mono.Cecil.Cil.Code.Castclass:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Castclass, declaringType);

                    break;
                }

                case Libs.Mono.Cecil.Cil.Code.Ceq:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ceq);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Cgt:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Cgt);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Cgt_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Cgt_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ckfinite:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ckfinite);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Clt:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Clt);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Clt_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Clt_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Constrained:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Constrained, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_I:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_I);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_I1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_I1);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_I2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_I2);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_I4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_I4);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_I8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_I8);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_I);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_I1);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I1_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_I1_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_I2);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I2_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_I2_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_I4);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I4_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_I4_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_I8);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I8_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_I8_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_I_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_I_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_U);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_U1);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U1_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_U1_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_U2);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U2_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_U2_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_U4);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U4_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_U4_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_U8);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U8_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_U8_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_Ovf_U_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_Ovf_U_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_R4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_R4);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_R8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_R8);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_R_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_R_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_U:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_U);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_U1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_U1);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_U2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_U2);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_U4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_U4);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Conv_U8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Conv_U8);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Cpblk:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Cpblk);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Cpobj:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Cpobj, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Div:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Div);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Div_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Div_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Dup:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Dup);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Endfilter:
                {

#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Endfilter);
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Endfinally:
                {
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Endfinally);
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Initblk:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Initblk);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Initobj:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Initobj, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Isinst:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Isinst, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Jmp:
                case Libs.Mono.Cecil.Cil.Code.Ldftn:
                case Libs.Mono.Cecil.Cil.Code.Ldvirtftn:
                {

                    var methodReference = (MethodReference)instructionDefinition.Operand;

                    var declaringBound = Execution.Types.Ensuring.EnsureBound(conversion, methodReference.DeclaringType);

                    if ((declaringBound is ConvertedTypeDefinition_I convertedType)
                        && Types.Building.CheckForPhase3Dependency(convertedType, (ConvertedTypeDefinition_I)routine.DeclaringType, true))
                    {
                        throw new Exception("Could not find member.  Need to gracefully exit and comeback.");
                    }

                    if (!Members.GetMemberInfo(conversion, routine.DeclaringType, routine, declaringBound, methodReference, out MemberInfo memberInfo))
                    {
                        throw new Exception("Could not find member.");
                    }

                    ilGenerator.Emit(opCode, (MethodInfo)memberInfo);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarg:
                {
                    if (instructionDefinition.Operand is ParameterDefinition parameter)
                    {
                        

                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg, (ushort)parameter.Sequence);
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg, (ushort)instructionDefinition.Operand);
                    }

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarga:
                {
                    if (instructionDefinition.Operand is ParameterDefinition parameter)
                    {
                        

                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarga, (ushort)parameter.Sequence);
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarga, (ushort)instructionDefinition.Operand);
                    }
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarga_S:
                {
                    if (instructionDefinition.Operand is ParameterDefinition parameter)
                    {
                        

                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarga_S, (byte)parameter.Sequence);
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarga_S, (byte)instructionDefinition.Operand);
                    }

                    break;
                }

                case Libs.Mono.Cecil.Cil.Code.Ldarg_0:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarg_1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_1);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarg_2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_2);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarg_3:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_3);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldarg_S:
                {
                    // https://msdn.microsoft.com/en-us/library/system.reflection.emit.opcodes.ldarga_s(v=vs.110).aspx

                    if (instructionDefinition.Operand is ParameterDefinition parameter)
                    {
                        

                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_S, (byte)parameter.Sequence);
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_S, (byte)instructionDefinition.Operand);
                    }

                    break;
                }
                // Constant Loading - Push the supplied integer value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4:
                {
                    int integerValue = (int)instructionDefinition.Operand;

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4, integerValue);
                    break;
                }
                // Constant Loading - Push the supplied integer value of 0 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_0:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_0);
                    break;
                }
                // Constant Loading - Push the supplied integer value of 1 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_1);
                    break;
                }
                // Constant Loading - Push the supplied integer value of 2 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_2);
                    break;
                }
                // Constant Loading - Push the supplied integer value of 3 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_3:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_3);
                    break;
                }
                // Constant Loading - Push the supplied integer value of 4 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_4);
                    break;
                }
                // Constant Loading - Push the supplied integer value of 5 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_5:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_5);
                    break;
                }
                // Constant Loading - Push the supplied integer value of 6 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_6:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_6);
                    break;
                }
                // Constant Loading - Push the supplied integer value of 7 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_7:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_7);
                    break;
                }
                // Constant Loading - Push the supplied integer value of 8 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_8);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_M1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_M1);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_I4_S:
                {
                    sbyte integerValue = (sbyte)instructionDefinition.Operand;

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_S, integerValue);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_I8:
                {
                    long integerValue = (long)instructionDefinition.Operand;

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I8, integerValue);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_R4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_R4, (float)instructionDefinition.Operand);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldc_R8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_R8, (double)instructionDefinition.Operand);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldnull:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldnull);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Leave:
                {
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Leave, Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Leave_S:
                {
#pragma warning disable 162
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (!UseILGeneratorExceptionHandling)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Leave_S,
                            Labeling.GetLabel(labelEntries, instructionDefinition));
                    }
#pragma warning restore 162
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelema:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelema, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_Any:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_I);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_I1);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_I2);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_I4);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_I8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_I8);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_R4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_R4);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_R8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_R8);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_Ref:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_Ref);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_U1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_U1);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_U2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_U2);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldelem_U4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_U4);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldfld:
                {
                    var fieldReference = (FieldReference)instructionDefinition.Operand;

                    var declaringBound = Execution.Types.Ensuring.EnsureBound(conversion, fieldReference.DeclaringType);

                    if ((declaringBound is ConvertedTypeDefinition_I convertedType)
                        && Types.Building.CheckForPhase3Dependency(convertedType, (ConvertedTypeDefinition_I)routine.DeclaringType, true))
                    {
                        throw new Exception("Fields not build yet.");
                    }

                    FieldInfo fieldInfo = Models.Fields.ResolveFieldReference(conversion, typeBeingBuilt, declaringBound, fieldReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldfld, fieldInfo);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldflda:
                {
                    var fieldReference = (FieldReference)instructionDefinition.Operand;

                    var declaringBound = Execution.Types.Ensuring.EnsureBound(conversion, fieldReference.DeclaringType);

                    if ((declaringBound is ConvertedTypeDefinition_I convertedType)
                        && Types.Building.CheckForPhase3Dependency(convertedType, (ConvertedTypeDefinition_I)routine.DeclaringType, true))
                    {
                        throw new Exception("Fields not build yet.");
                    }

                    FieldInfo fieldInfo = Models.Fields.ResolveFieldReference(conversion, typeBeingBuilt, declaringBound, fieldReference);

                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldflda, fieldInfo);

                    break;
                }
               

                case Libs.Mono.Cecil.Cil.Code.Ldlen:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldlen);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_I:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldind_I);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_I1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldind_I1);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_I2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldind_I2);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_I4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldind_I4);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_I8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldind_I8);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_R4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldind_R4);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_R8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldind_R8);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_Ref:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldind_Ref);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_U1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldind_U1);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_U2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldind_U2);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldind_U4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldind_U4);
                    break;
                }
                // Local Load - Push the local value at the location specified by the supplied short value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc:
                {
                    if (instructionDefinition.Operand is VariableDefinition variable)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloc, (short)variable.Index);
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloc, (short)instructionDefinition.Operand);
                    }

                    break;
                }
                // Local Load - Push the address of the local value at the location specified by the supplied short value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloca:
                {
                    if (instructionDefinition.Operand is VariableDefinition variable)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloca, (short)variable.Index);
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloca, (short)instructionDefinition.Operand);
                    }

                    break;
                }
                // Local Load - Push the address of the local value at the location specified by the supplied byte value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloca_S:
                {
                    if (instructionDefinition.Operand is VariableDefinition variable)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloca_S, (byte)variable.Index);
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloca_S, (byte)instructionDefinition.Operand);
                    }

                    break;
                }
                // Local Load - Push the local value 0 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc_0:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloc_0);
                    break;
                }
                // Local Load - Push the local value 0 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc_1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloc_1);
                    break;
                }
                // Local Load - Push the local value 0 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc_2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloc_2);
                    break;
                }
                // Local Load - Push the local value 0 onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc_3:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloc_3);
                    break;
                }
                // Local Load - Push the local value at the location specified by the supplied byte value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Ldloc_S:
                {
                    if (instructionDefinition.Operand is VariableDefinition variable)
                    {
                        //ConvertedMethodParameterMask_I convertedParameter = GetParameter(method, parameter);

                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloc_S, (byte)variable.Index);
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloc_S, (byte)instructionDefinition.Operand);
                    }

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldobj:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldobj, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldsfld:
                {
                    var fieldReference = (FieldReference)instructionDefinition.Operand;

                    var declaringBound = Execution.Types.Ensuring.EnsureBound(conversion, fieldReference.DeclaringType);

                    if ((declaringBound is ConvertedTypeDefinition_I convertedType)
                        && Types.Building.CheckForPhase3Dependency(convertedType, (ConvertedTypeDefinition_I)routine.DeclaringType, true))
                    {
                        throw new Exception("Fields not build yet.");
                    }

                    FieldInfo fieldInfo = Models.Fields.ResolveFieldReference(conversion, typeBeingBuilt, declaringBound, fieldReference);

                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldsfld, fieldInfo);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldsflda:
                {
                    var fieldReference = (FieldReference)instructionDefinition.Operand;

                    var declaringBound = Execution.Types.Ensuring.EnsureBound(conversion, fieldReference.DeclaringType);

                    if ((declaringBound is ConvertedTypeDefinition_I convertedType)
                        && Types.Building.CheckForPhase3Dependency(convertedType, (ConvertedTypeDefinition_I)routine.DeclaringType, true))
                    {
                        throw new Exception("Fields not build yet.");
                    }

                    FieldInfo fieldInfo = Models.Fields.ResolveFieldReference(conversion, typeBeingBuilt, declaringBound, fieldReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldsflda, fieldInfo);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldstr:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldstr, (string)instructionDefinition.Operand);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ldtoken:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    System.Type resolvedType;

                    if (typeReference is GenericParameter genericParameter)
                    {
                        // This hard cast is safe as constructors do not have generic parameters.
                        if (!Instructions.GetGenericParameterType(conversion, routine.DeclaringType, routine,
                            genericParameter, out resolvedType))
                        {
                            throw new Exception("Type not ready to emit tokens.");
                        }
                    }
                    else
                    {
                        resolvedType = Execution.Types.Ensuring.EnsureToType(conversion, typeReference);
                    }


                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldtoken, resolvedType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Localloc:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Localloc);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Mkrefany:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Mkrefany, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Mul:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Mul);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Mul_Ovf:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Mul_Ovf);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Mul_Ovf_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Mul_Ovf_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Neg:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Neg);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Newarr:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Newarr, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Newobj:
                {
                    var methodReference = (MethodReference)instructionDefinition.Operand;

                    // Created during pre-scan
                    var convertedInstruction = routine.ConvertedInstructions[instructionDefinition.Offset];

                    // how does the member reference declaring type be resolved?
                    var declaringBound = convertedInstruction.OperandDeclaringType;

                    var found = Constructors.Getting.GetConstructor(conversion, typeBeingBuilt, declaringBound, methodReference, out MemberInfo memberInfo);

                    if (!found)
                    {
                        throw new Exception("Constructor not found.  This needs to gracefully exit and comeback.");
                    }

                    if (memberInfo is ConstructorInfo constructorInfo)
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Newobj, constructorInfo);
                    }
                    else if (memberInfo is MethodInfo methodInfo)
                    {
                        // Possible for multidimensional array creation
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Newobj, methodInfo);
                    }
                    else
                    {
                        throw new System.Exception("Not a constructor or  method");
                    }

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Nop:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Nop);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Not:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Not);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Pop:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Pop);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Or:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Or);
                    break;
                }

                case Libs.Mono.Cecil.Cil.Code.Readonly:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Readonly);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Refanytype:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Refanytype);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Refanyval:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Refanyval, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Rem:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Rem);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Rem_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Rem_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Ret:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ret);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Rethrow:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Rethrow);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Sizeof:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Sizeof, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Starg:
                {
                    if (instructionDefinition.Operand is ParameterDefinition parameter)
                    {
                        

                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Starg, (ushort)parameter.Sequence);
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Starg, (ushort)instructionDefinition.Operand);
                    }
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Starg_S:
                {
                    if (instructionDefinition.Operand is ParameterDefinition parameter)
                    {
                        

                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Starg_S, (byte)parameter.Sequence);
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Starg_S, (byte)instructionDefinition.Operand);
                    }

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_Any:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stelem);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_I:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stelem_I);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_I1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stelem_I1);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_I2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stelem_I2);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_I4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stelem_I4);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_I8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stelem_I8);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_R4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stelem_R4);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_R8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stelem_R8);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stelem_Ref:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stelem_Ref);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stfld:
                {
                    var fieldReference = (FieldReference)instructionDefinition.Operand;

                    var declaringBound = Execution.Types.Ensuring.EnsureBound(conversion, fieldReference.DeclaringType);

                    if ((declaringBound is ConvertedTypeDefinition_I convertedType)
                        && Types.Building.CheckForPhase3Dependency(convertedType, (ConvertedTypeDefinition_I)routine.DeclaringType, true))
                    {
                        throw new Exception("Fields not build yet.");
                    }

                    FieldInfo fieldInfo = Models.Fields.ResolveFieldReference(conversion, typeBeingBuilt, declaringBound, fieldReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stfld, fieldInfo);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stsfld:
                {
                    var fieldReference = (FieldReference)instructionDefinition.Operand;

                    var declaringBound = Execution.Types.Ensuring.EnsureBound(conversion, fieldReference.DeclaringType);

                    if ((declaringBound is ConvertedTypeDefinition_I convertedType)
                        && Types.Building.CheckForPhase3Dependency(convertedType, (ConvertedTypeDefinition_I)routine.DeclaringType, true))
                    {
                        throw new Exception("Fields not build yet.");
                    }

                    FieldInfo fieldInfo = Models.Fields.ResolveFieldReference(conversion, typeBeingBuilt, declaringBound, fieldReference);

                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stsfld, fieldInfo);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stind_I:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stind_I);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stind_I1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stind_I1);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stind_I2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stind_I2);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stind_I4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stind_I4);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stind_I8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stind_I8);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stind_R4:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stind_R4);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stind_R8:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stind_R8);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stind_Ref:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stind_Ref);
                    break;
                }
                // Local Store - Pops the value on the stack and stores it in local location specified by the supplied short value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Stloc:
                {
                    if (instructionDefinition.Operand is VariableDefinition variable)
                    {
                        //ConvertedMethodParameterMask_I convertedParameter = GetParameter(method, parameter);

                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stloc, (ushort)variable.Index);
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stloc, (ushort)instructionDefinition.Operand);
                    }


                    break;
                }
                // Local Store - Pops the value on the stack and stores it in local 0
                case Libs.Mono.Cecil.Cil.Code.Stloc_0:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stloc_0);
                    break;
                }
                // Local Store - Pops the value on the stack and stores it in local 1
                case Libs.Mono.Cecil.Cil.Code.Stloc_1:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stloc_1);
                    break;
                }
                // Local Store - Pops the value on the stack and stores it in local 2
                case Libs.Mono.Cecil.Cil.Code.Stloc_2:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stloc_2);
                    break;
                }
                // Local Store - Pops the value on the stack and stores it in local 3
                case Libs.Mono.Cecil.Cil.Code.Stloc_3:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stloc_3);
                    break;
                }
                // Local Store - Pops the value on the stack and stores it in local location specified by the supplied byte value onto the stack
                case Libs.Mono.Cecil.Cil.Code.Stloc_S:
                {
                    if (instructionDefinition.Operand is VariableDefinition variable)
                    {
                        //ConvertedMethodParameterMask_I convertedParameter = GetParameter(method, parameter);

                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stloc_S, (byte)variable.Index);
                    }
                    else
                    {
                        ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stloc_S, (byte)instructionDefinition.Operand);
                    }


                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Shl:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Shl);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Shr:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Shr);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Shr_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Shr_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Stobj:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Stobj, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Sub:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Sub);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Sub_Ovf:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Sub_Ovf);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Sub_Ovf_Un:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Sub_Ovf_Un);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Switch:
                {
                    if (!switchEntries.TryGetValue(instructionDefinition.Offset, out ConvertedLabel switchEntry))
                    {
                        throw new Exception($"Did not find a switch statement at offset {instructionDefinition.Offset}.");
                    }

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Switch, switchEntry.Labels);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Tail:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Tailcall);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Throw:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Throw);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Unaligned:
                {
                    byte alignment = (byte)instructionDefinition.Operand;

                    // TODO: does not handle case: ILGenerator.Emit(OpCode, Label)
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Unaligned, alignment);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Unbox:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Unbox, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Unbox_Any:
                {
                    var typeReference = instructionDefinition.Operand as TypeReference;

                    var declaringType = EnsureToType(conversion, typeBeingBuilt, routine, typeReference);

                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Unbox_Any, declaringType);

                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Volatile:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Volatile);
                    break;
                }
                case Libs.Mono.Cecil.Cil.Code.Xor:
                {
                    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Xor);
                    break;
                }
                default:
                {
                    //No = 214,
                    throw new System.Exception($"Code {instructionDefinition.OpCode.Code.ToString()} not handled.");
                }
            }
        }

        private System.Type EnsureToType(ILConversion conversion, ConvertedTypeDefinition_I typeBeingBuilt, ConvertedRoutine routine, TypeReference typeReference)
        {
            var context = new ExecutionEnsureContext()
            {
                Conversion = conversion,
                TypeReference = typeReference,
                MethodReference = routine.MethodReference,
                RoutineDeclaringType = typeBeingBuilt
            };

            return Execution.Types.Ensuring.EnsureToType(context);
        }

        private bool ScanILForBranchesAndTypes(ILConversion conversion, ConvertedTypeDefinition_I typeBeingBuilt, ConvertedRoutine routine)
        {
            if (routine.IsBranchAndTypeScanComplete) return false;

            var methodDefinition = (MethodDefinition)routine.MethodReference;

            var ilGenerator = routine.IlGenerator;

            var labelEntries = routine.LabelEntries;

            var switchEntries = routine.SwitchEntries;

            var foundDependencies = false;

            foreach (var instructionDefinition in methodDefinition.Body.Instructions)
            {
                BoundTypeDefinitionMask_I operandDeclaringType = null;


                // detect and build labels
                switch (instructionDefinition.OpCode.Code)
                {
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
                        if (typeBeingBuilt.FullName ==
                            "Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Assemblies.AssemblyDomainApi")
                        {
                            var targetInstructionOffset = ((Instruction)instructionDefinition.Operand).Offset;
                            var currentOffset = instructionDefinition.Offset;
                            var diff = targetInstructionOffset - currentOffset;

                            if (diff < -100 || diff > 100)
                            {


                            }

                        }





                        CreateAndAssociateLabelWithTargetInstruction(instructionDefinition, labelEntries, ilGenerator);

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
                        CreateAndAssociateLabelWithTargetInstruction(instructionDefinition, labelEntries, ilGenerator);

                        break;
                    }
                    case Libs.Mono.Cecil.Cil.Code.Switch:
                    {
                        var instructions = (Instruction[])instructionDefinition.Operand;

                        var labels = new Label[instructions.Length];

                        for (int i = 0; i < instructions.Length; i++)
                        {
                            var instruction = instructions[i];

                            Label label;

                            var offset = instruction.Offset;

                            if (labelEntries.TryGetValue(offset, out ConvertedLabel existingLabelEntry))
                            {
                                label = existingLabelEntry.Label;
                            }
                            else
                            {
                                label = ilGenerator.DefineLabel();

                                var labelEntry = new ConvertedLabel()
                                {
                                    Offset = offset,
                                    Label = label
                                };

                                labelEntries.Add(labelEntry.Offset, labelEntry);
                            }

                            labels[i] = label;
                        }

                        var switchEntry = new ConvertedLabel()
                        {
                            Offset = instructionDefinition.Offset,
                            Labels = labels
                        };

                        switchEntries.Add(switchEntry.Offset, switchEntry);

                        break;
                    }
                    case Libs.Mono.Cecil.Cil.Code.Call:
                    case Libs.Mono.Cecil.Cil.Code.Callvirt:
                    case Libs.Mono.Cecil.Cil.Code.Jmp:
                    case Libs.Mono.Cecil.Cil.Code.Ldftn:
                    case Libs.Mono.Cecil.Cil.Code.Ldvirtftn:
                    case Libs.Mono.Cecil.Cil.Code.Newobj:
                    {
                        var methodReference = (MethodReference)instructionDefinition.Operand;

                        operandDeclaringType = Execution.Types.Ensuring.EnsureBound(conversion, methodReference.DeclaringType);

                        break;
                    }
                    case Libs.Mono.Cecil.Cil.Code.Calli:
                    {
                        throw new System.NotSupportedException("Calli instruction not supported yet.");
                    }
                    case Libs.Mono.Cecil.Cil.Code.Ldfld:
                    case Libs.Mono.Cecil.Cil.Code.Ldflda:
                    case Libs.Mono.Cecil.Cil.Code.Ldsfld:
                    case Libs.Mono.Cecil.Cil.Code.Ldsflda:
                    case Libs.Mono.Cecil.Cil.Code.Stfld:
                    case Libs.Mono.Cecil.Cil.Code.Stsfld:
                    {
                        var fieldReference = (FieldReference)instructionDefinition.Operand;

                        operandDeclaringType = Execution.Types.Ensuring.EnsureBound(conversion, fieldReference.DeclaringType);

                        break;
                    }
                    default:
                    {
                        break;
                    }
                }

                if (operandDeclaringType == null) continue;

                var convertedInstruction = new ConvertedInstruction()
                {
                    OperandDeclaringType = operandDeclaringType
                };

                routine.ConvertedInstructions.Add(instructionDefinition.Offset, convertedInstruction);

                if (!(operandDeclaringType is ConvertedTypeDefinition_I convertedType)) continue;

                foundDependencies |= Types.Building.CheckForPhase3Dependency(convertedType, typeBeingBuilt, true);
            }

            routine.IsBranchAndTypeScanComplete = true;

            return foundDependencies;

        }

        private void CreateAndAssociateLabelWithTargetInstruction(Instruction instructionDefinition,
            Dictionary<int, ConvertedLabel> labelEntries, ILGenerator ilGenerator)
        {
            Instruction instruction = (Instruction)instructionDefinition.Operand;

            var offset = (int)instruction.Offset;

            if (labelEntries.ContainsKey(offset))
            {
                return;
            }

            ConvertedLabel labelEntry = new ConvertedLabel()
            {
                Offset = offset,
                Label = ilGenerator.DefineLabel()
            };

            labelEntries.Add(labelEntry.Offset, labelEntry);

        }

        public void AddDependentOrDependency(Dictionary<string, ConvertedTypeDefinition_I> dictionary, ConvertedTypeDefinition_I converted)
        {

            if (!dictionary.ContainsKey(converted.ResolutionName))
            {
                dictionary.Add(converted.ResolutionName, converted);
            }
        }

        private void DeclareLocalVariables(ILConversion conversion, ConvertedRoutine routine)
        {
            if (routine.AreLocalVariablesDeclared) return;

            var methodDefinition = (MethodDefinition)routine.MethodReference;

            var ilGenerator = routine.IlGenerator;

            if (methodDefinition.Body.HasVariables)
            {
                foreach (var variable in methodDefinition.Body.Variables)
                {
                    var variableTypeReference = variable.VariableType;

                    System.Type variableType = Execution.Types.Ensuring.EnsureToType(conversion, variableTypeReference);

                    LocalBuilder localBuilder = ilGenerator.DeclareLocal(variableType);
                }
            }

            routine.AreLocalVariablesDeclared = true;
        }

        
    }
}
