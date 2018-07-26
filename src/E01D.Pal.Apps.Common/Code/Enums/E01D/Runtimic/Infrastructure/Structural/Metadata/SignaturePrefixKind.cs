using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Code.Enums.E01D.Runtimic.Infrastructure.Structural.Metadata
{
	public enum SignaturePrefixKind:byte
	{
		Unknown = 0x0,
		Field = CallingConventionKind.Field,
		/// <summary>
		/// Specifies that the signature is of a local's section of a method or constructor.
		/// </summary>
		LocalsSignature = CallingConventionKind.LocalsSignature,
		Property = 0x08
	}
}
