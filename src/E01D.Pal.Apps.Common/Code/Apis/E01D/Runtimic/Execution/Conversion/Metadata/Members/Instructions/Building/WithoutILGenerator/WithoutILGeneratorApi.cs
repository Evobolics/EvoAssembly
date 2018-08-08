using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator.IL;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;

// https://csharp.hotexamples.com/site/file?hash=0xd48fc662d362b9e1a73dd1c74d5531dbb92da71c785126a184864f8dd82dc38d&fullName=src/Scripting/Core/ReflectionEmitter.cs&project=furesoft/roslyn
// https://github.com/dotnet/roslyn/commit/49e80836d6a0748e028abb258904b6253103a20f#diff-c58a7b6d4b74da61d78e849299ce3f76

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator
{
	public class WithoutILGeneratorApi<TContainer> : ConversionApiNode<TContainer>, WithoutILGeneratorApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public ExceptionHandlingApi_I<TContainer> ExceptionHandling { get; set; }

		ExceptionHandlingApiMask_I WithoutILGeneratorApiMask_I.ExceptionHandling => ExceptionHandling;

		public ILApi_I<TContainer> IL { get; set; }

		ILApiMask_I WithoutILGeneratorApiMask_I.IL => IL;

        public LocalVariableSignatureApi_I<TContainer> LocalVariableSignatures { get; set; }

        LocalVariableSignatureApiMask_I WithoutILGeneratorApiMask_I.LocalVariableSignatures => LocalVariableSignatures;

        public bool BuildBody(ILConversion conversion, ConvertedRoutine routine)
        {
	        // If for some reason this is being called on a method that is not a method definition, then go ahead and mark it fully built
	        // and return true, as there is nothing else to be done.  
	        // POSSIBLE ERROR CONDITION IN THE FUTURE.  NEED TO SEE HOW INTERFACES DEFINITIONS ARE HANDLED.
	        if (!routine.MethodReference.IsDefinition)
	        {
		        throw new System.Exception("The non-method definitions body is being emitted.  This should not occur and should have been prevented " +
		                                   "by the caller.");
	        }

			if (routine.EmitState.Body == null)
	        {
		        routine.EmitState.Body = new ConvertedRoutineBodyEmitState();
	        }

			var bodyEmitState = routine.EmitState.Body;

			// If the body has already been fully built, then all the information is in the emit state.
			if (bodyEmitState.BodyFullyBuilt) return true;

			var methodDefinition = (MethodDefinition)routine.MethodReference;

			// 1) Build the local variable signature.  
			//    This is an array of bytes that contain the serialized local variable
			//    structure. Specify null if the method has no local variables.  This method returns false 
			//    if a dependency is detected that is not yet been satisfied.
			if (!LocalVariableSignatures.GetLocalSignature(conversion, routine))
			{
				// Dependency found that was not satisfied.
				return false;
			}

	        if (routine.MethodReference.FullName ==
	            "T Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions.InstructionTest_CastClass::Get(Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.Interface1)"
	        )
	        {

	        }

			// 2) Build the IL Stream.  This method returns false if a dependency is detected that is not yet
			//    been satisfied.
			if (!IL.EmitILStream(conversion, routine))
			{
				// Dependency found that was not satisfied.
				return false;
			}

	        // 3) Build the IL Stream.  This method returns false if a dependency is detected that is not yet
	        //    been satisfied.
			if (!ExceptionHandling.GetExceptionHandlerList(conversion, routine))
			{
				// Dependency found that was not satisfied.
				return false;
			}

	        // 4) Set max stack - This is put last in case the IL code ever computes the max stack size and cannot be determined
			//                    prior to IL emission.
	        bodyEmitState.MaxStack = methodDefinition.Body.MaxStackSize;

			// Mark the methods body as fully built.
	        bodyEmitState.BodyFullyBuilt = true;

			// Do unsatisfied dependencies were found.
			return true;

			
		}


	}
}
