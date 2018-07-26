using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Code.Enums.E01D.Runtimic.Infrastructure.Structural.Metadata
{
	public enum ElementKind // See II.23.1.16
	{
		/// <summary>
		/// Marks the end of a list
		/// </summary>
		End = 0x00,
		Void = 0x01,
		Boolean = 0x02,
		Char = 0x03,
		I1 = 0x04,
		U1 = 0x05,
		I2 = 0x06,
		U2 = 0x07,
		I4 = 0x08,
		U4 = 0x09,
		I8 = 0x0a,
		U8 = 0x0b,
		R4 = 0x0c,
		R8 = 0x0d,
		String = 0x0e,
		Ptr = 0x0f,   // Followed by <type> token
		ByRef = 0x10,   // Followed by <type> token
		ValueType = 0x11,   // Followed by <type> token
		Class = 0x12,   // Followed by <type> token
		Var = 0x13,   // Followed by generic parameter number
		Array = 0x14,   // <type> <rank> <boundsCount> <bound1>  <loCount> <lo1>
		GenericInst = 0x15,   // <type> <type-arg-count> <type-1> ... <type-n> */
		TypedByRef = 0x16,
		I = 0x18,   // System.IntPtr
		U = 0x19,   // System.UIntPtr
		FnPtr = 0x1b,   // Followed by full method signature
		Object = 0x1c,   // System.Object
		/// <summary>
		/// Single-dim array with 0 lower bound
		/// </summary>
		SzArray = 0x1d,   
		/// <summary>
		/// Generic parameter in a generic method definition, represented as a compressed unsigned integer
		/// </summary>
		MVar = 0x1e,   // Followed by generic parameter number
		/// <summary>
		/// An required modifier that is followed by a TypeDef or TypeRef token
		/// </summary>
		CModReqD = 0x1f,   
		/// <summary>
		/// An optional modifiers that is followed by a TypeDef or TypeRef token
		/// </summary>
		CModOpt = 0x20,   // Optional modifier : followed by a TypeDef or TypeRef token
		/// <summary>
		/// Implemented within the CLI
		/// </summary>
		Internal = 0x21,   
		/// <summary>
		/// Or'd with following element types
		/// </summary>
		Modifier = 0x40,   
		/// <summary>
		/// Sentinel for varargs method signature
		/// </summary>
		Sentinel = 0x41,   
		/// <summary>
		/// Denotes a local variable that points at a pinned object
		/// </summary>
		Pinned = 0x45,
		/// <summary>
		/// Indicates an argument of System.Type
		/// </summary>
		Type = 0x50,
		/// <summary>
		/// Used in custom attributes to specify a boxed object.
		/// </summary>
		Boxed = 0x51,
		/// <summary>
		/// Reserved - not currently used.
		/// </summary>
		Reserved = 0x52,
		/// <summary>
		/// Used in custom attributes to indicate a field.
		/// </summary>
		Field = 0x53,
		/// <summary>
		/// Used in custom attributes to indicate a property
		/// </summary>
		Property = 0x54,
		/// <summary>
		/// Used in custom attributes to indicate an enum.
		/// </summary>
		Enum = 0x55
	}
}
