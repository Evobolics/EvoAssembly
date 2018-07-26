using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	public class BoundEnsureContext
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
	}

	public class BoundEnsureContext<T>:BoundEnsureContext
	{
		
	}
}
