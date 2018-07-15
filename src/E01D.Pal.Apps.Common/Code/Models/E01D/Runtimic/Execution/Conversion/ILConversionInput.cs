using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
	public abstract class ILConversionInput
	{
		public abstract InputOutputKind Kind { get;}

		/// <summary>
		/// A complete list of of the assembly definitions that have one or more types being converted.
		/// </summary>
		public List<UnifiedAssemblyNode> AssemlyNodesToConvert { get; set; }

		/// <summary>
		/// A complete list of all the type references that MUST be converted.  Type references are used over type definitions because generic types
		/// can be passed.  Additional type references may be converted if they reference
		/// a type reference that are part of the same assembly of a type reference already in this list. 
		/// </summary>
		/// <returns>Returns a list of type references. It is a list because the input into the method that creates a list is a IEnumerable and the count cannot be determined
		/// till the items have been enumerated.  Therefore it is not an array as the list would have to be iterated twice.</returns>
	
		public List<UnifiedTypeNode> NodesToConvert { get; set; }
	}
}
