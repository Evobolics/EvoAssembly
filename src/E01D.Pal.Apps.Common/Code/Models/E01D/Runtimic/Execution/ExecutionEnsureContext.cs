using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution
{
	public class ExecutionEnsureContext
	{
		/// <summary>
		/// Gets or sets the type reference that is being ensured.
		/// </summary>
		public TypeReference TypeReference { get; set; }

		/// <summary>
		/// Gets or sets the declaring type that would contain the type being ensured.
		/// </summary>
		public BoundTypeDefinitionMask_I DeclaringType { get; set; }

		/// <summary>
		/// The underlying type associated with type reference that will be combined with the type reference to a single entry.
		/// </summary>
		public System.Type UnderlyingType { get; set; }

		public MethodReference MethodReference { get; set; }
		public ConvertedTypeDefinitionMask_I RoutineDeclaringType { get; set; }

		/// <summary>
		/// Gets or sets whether the type is converted, or not, or do not know.
		/// </summary>
		public bool? IsConverted { get; set; } = null; // do not know, another variable is needed.  Till then, the reality is not decided.

		public ConvertedAssemblyNode AssemblyNode { get; set; }
		public ModuleDefinition ModuleDefinition { get; set; }
		public StructuralTypeNode StructuralInputTypeNode { get; set; }

		public RuntimicSystemModel RuntimicSystem { get; set; }

		public ILConversion Conversion { get; set; }
		public ExecutionTypeNodeMask_I ExecutionTypeNode { get; set; }
		public int RowId { get; set; }
		public ConvertedTypeDefinition_I ConvertedDeclaringType { get; set; }
	}

	public class BoundEnsureContext<T>:ExecutionEnsureContext
	{
		
	}
}
