using System;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithILGenerator;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building
{
    public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
    where TContainer : RuntimicContainer_I<TContainer>
    {
        

	    public WithILGeneratorApi_I<TContainer> WithILGenerator { get; set; }

	    WithILGeneratorApiMask_I BuildingApiMask_I.WithILGenerator => WithILGenerator;

	    public WithoutILGeneratorApi_I<TContainer> WithoutILGenerator { get; set; }

	    WithoutILGeneratorApiMask_I BuildingApiMask_I.WithoutILGenerator => WithoutILGenerator;

		public bool BuildInstructions(ILConversion conversion, ConvertedTypeDefinition_I convertedType)
        {
	        if (conversion.Configuration.UseILGenerator)
	        {
		        //return WithILGenerator.GenerateIL(conversion, convertedType);
				throw new NotSupportedException("The use of the IL generator is  no longer supported.");
		        
	        }
	        
		    if (!(convertedType is ConvertedTypeWithRoutines_I convertedWithRoutines)) return true;

	        if (convertedWithRoutines.RoutinesEmitState == null)
	        {
				convertedWithRoutines.RoutinesEmitState = new ConvertedRoutinesEmitState();
			}

	        var currentRoutineToEmit = convertedWithRoutines.RoutinesEmitState.CurrentRoutineToEmit;

			for (int i = currentRoutineToEmit; i < convertedWithRoutines.Routines.Count; convertedWithRoutines.RoutinesEmitState.CurrentRoutineToEmit = ++i)
		    {
			    var routine = convertedWithRoutines.Routines[i];

			    if (!BuildRoutineBody(conversion, routine)) return false;
			}

	        return true;

        }

	    private bool BuildRoutineBody(ILConversion conversion, ConvertedRoutineMask_I routine)
	    {
			if (!routine.MethodReference.IsDefinition) return true;

			var methodDefinition = (MethodDefinition)routine.MethodReference;

		    if (!methodDefinition.HasBody) return true;

		    if (!(routine is ConvertedRoutine convertedRoutine))
		    {
			    throw new Exception($"Expected the routine to be of type type {typeof(ConvertedRoutine)}");
		    }

		    if (convertedRoutine.EmitState == null)
		    {
				convertedRoutine.EmitState = new ConvertedRoutineEmitState();
			}

		    if (routine.MethodReference.FullName ==
		        "T Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions.InstructionTest_CastClass::Get(Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.Interface1)"
		    )
		    {
			    
		    }

		    if (!WithoutILGenerator.BuildBody(conversion, convertedRoutine))
		    {
			    return false;
		    }

		    if (routine is ConvertedEmittedConstructor emittedConstructor)
		    {
			    var emitState = convertedRoutine.EmitState.Body;
			    emittedConstructor.ConstructorBuilder.InitLocals = methodDefinition.Body.InitLocals;
			    emittedConstructor.ConstructorBuilder.SetMethodBody(
				    emitState.InstructionStream.Buffer,
				    emitState.MaxStack,
				    emitState.LocalSignature,
				    emitState.ExceptionHandlers,
				    emitState.TokenFixups);
		    }
		    else if (routine is ConvertedBuiltMethod emittedMethod)
		    {
			    var emitState = convertedRoutine.EmitState.Body;
			    emittedMethod.MethodBuilder.InitLocals = methodDefinition.Body.InitLocals;
			    emittedMethod.MethodBuilder.SetMethodBody(
				    emitState.InstructionStream.Buffer,
				    emitState.MaxStack,
				    emitState.LocalSignature,
				    emitState.ExceptionHandlers,
				    emitState.TokenFixups);
		    }

		    return true;
	    }
    }
}
