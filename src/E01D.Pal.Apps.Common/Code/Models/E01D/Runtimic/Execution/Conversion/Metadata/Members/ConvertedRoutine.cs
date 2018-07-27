using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.IL;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    /// <summary>
    /// The base class for a constructor OR a method that contains the properties that they share in common.  
    /// This allows for routine searching algoirthms to be created.
    /// </summary>
    public abstract class ConvertedRoutine: ConvertedMemberWithDeclaringType, ConvertedRoutineMask_I
    {
		/// <summary>
		/// Gets or sets the body of the routine.
		/// </summary>
		public ConvertedRoutineBody Body { get; set; }

		public ILGenerator IlGenerator { get; set; }

        public MethodReference MethodReference { get; set; }

		public ConvertedRoutineEmitState EmitState { get; set; }


		public ConvertedRoutineParameters_I Parameters { get; set; } = new ConvertedRoutineParameters();

        BoundRoutineParametersMask_I BoundRoutineDefinitionMask_I.Parameters => Parameters;
        SemanticRoutineParametersMask_I SemanticRoutineMask_I.Parameters => Parameters;

        /// <summary>
        /// Gets or sets the return type for a routine.  
        /// </summary>
        /// <remarks>
        /// For a constructor, this should always be set to the return type of 'System.Void'.  In C#, this return type is 
        /// implicit, since the compiler does not require it to be present.  But in IL, this is specified.  By haivng the 
        /// return type in the routine, it simplifies routine matching algorithms.
        /// </remarks>
        public BoundTypeDefinitionMask_I ReturnType { get; set; }

        public abstract MemberInfo UnderlyingMember { get; }
	    public bool AreLocalVariablesDeclared { get; set; }
	    public bool IsBranchAndTypeScanComplete { get; set; }
	    public ExceptionHandlingInfo ExceptionHandlingInfo { get; set; }
	    public bool IsExceptionHandlingInfoPreprocessed { get; set; }

	    public Dictionary<int, ConvertedInstruction> ConvertedInstructions { get; set; } = new Dictionary<int, ConvertedInstruction>();
	    public bool ILFullyEmitted { get; set; }

	    // TODO: // turn into extension method
		public abstract bool IsConstructor();

        public abstract bool IsMethod();

	    public Dictionary<int, ConvertedLabel> LabelEntries = new Dictionary<int, ConvertedLabel>();

	    public Dictionary<int, ConvertedLabel> SwitchEntries = new Dictionary<int, ConvertedLabel>();

		
	}
}
