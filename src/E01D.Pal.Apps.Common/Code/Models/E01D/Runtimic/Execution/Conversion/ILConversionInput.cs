using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
	public abstract class ILConversionInput
	{
		public abstract InputOutputKind Kind { get;}

		/// <summary>
		/// A complete list of assemblies to convert.
		/// </summary>
		public Assembly[] AssembliesToConvert { get; set; }

		/// <summary>
		/// A complete list of of the assembly definitions that have one or more types being converted.
		/// </summary>
		public Stream[] AssemblyStreamsToConvert { get; set; }

		/// <summary>
		/// A complete list of all the type references that MUST be converted.  Type references are used over type definitions because generic types
		/// can be passed.  Additional type references may be converted if they reference
		/// a type reference that are part of the same assembly of a type reference already in this list. 
		/// </summary>
		/// <returns>Returns a list of type references. It is a list because the input into the method that creates a list is a IEnumerable and the count cannot be determined
		/// till the items have been enumerated.  Therefore it is not an array as the list would have to be iterated twice.</returns>
	
		public TypeReference[] TypeReferencesToConvert { get; set; }

		public Type[] TypesToConvert { get; set; }
		public ILConversionOptions Options { get; set; }

		

		public Dictionary<long, ConversionTypeNode> TypeNodesToConvert { get; set; } =
			new Dictionary<long, ConversionTypeNode>();
	}
}
