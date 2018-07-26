using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator.IL;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

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

        public void BuildBody(ILConversion conversion, ConvertedTypeDefinition_I convertedType, ConvertedEmittedConstructor convertedConstructor)
		{
			var methodDefinition = (MethodDefinition)convertedConstructor.MethodReference;


			
			int maxStack = methodDefinition.Body.MaxStackSize;

			//var e01dLocalSignature = Signatures.GetLocalSignature(conversion, convertedConstructor);

			// An array of bytes that contain the serialized local variable structure. Specify null if the method has no local variables.
			byte[] localSignature = null;//LocalVariableSignatures.GetLocalSignature(conversion, convertedConstructor);
			

			var ilInstructionStream = IL.EmitILStream(conversion, convertedConstructor);


			var exceptionHandlerList = ExceptionHandling.GetExceptionHandlerList(conversion, convertedConstructor);
			int[] tokenFixups = new int[ilInstructionStream.FixupCount];

			Array.Copy(ilInstructionStream.Fixups, 0, tokenFixups, 0, ilInstructionStream.FixupCount);

			convertedConstructor.ConstructorBuilder.InitLocals = methodDefinition.Body.InitLocals;
			convertedConstructor.ConstructorBuilder.SetMethodBody(ilInstructionStream.Buffer, maxStack, localSignature, exceptionHandlerList, tokenFixups);

			//throw new Exception("Not using IL Generator");
		}

		
    }
}
