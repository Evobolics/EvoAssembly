using System.Reflection.Emit;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
	public class ConvertedRoutineBodyEmitState
	{
		/// <summary>
		/// Gets or sets whether the body has been fully built and is ready to be utilized by a ConstructorBuilder or a MethodBuilder.
		/// </summary>
		public bool BodyFullyBuilt { get; set; }

		public ExceptionHandler[] ExceptionHandlers { get; set; }

		public ConvertedILStream InstructionStream { get; set; }

		/// <summary>
		/// Gets or sets the computed local signature.
		/// </summary>
		public byte[] LocalSignature { get; set; }

		/// <summary>
		/// Gets or sets the max stack size.
		/// </summary>
		public int MaxStack { get; set; }

		public int[] TokenFixups { get; set; }
		public SignatureHelper SignatureHelper { get; set; }
		public int CurrentLocalVariable { get; set; }
		public int CurrentInstruction { get; set; }
		public int CurrentExceptionHandler { get; set; }
	}
}
