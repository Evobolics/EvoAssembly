namespace Root.Code.Enums.E01D.Runtimic.Infrastructure.Structural.Metadata
{
	public enum CallingConventionKind:byte
	{
		Default = 0x0,
		C = 0x1,
		StdCall = 0x2,
		ThisCall = 0x3,
		FastCall = 0x4,
		VarArg = 0x5,
		Field = 0x06,
		/// <summary>
		/// Specifies that the signature is of a local's section of a method or constructor.
		/// </summary>
		LocalsSignature = 0x07,
		Property = 0x08,
		Unmanaged = 0x09,
		Mask = 0x10,
		HasThis = 0x10,
		ExplicitThis = 0x10,
		Generic = 0x10,
	}
}
