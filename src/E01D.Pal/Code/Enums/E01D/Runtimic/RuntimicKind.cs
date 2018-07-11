using System;

namespace Root.Code.Enums.E01D.Runtimic
{
    [Flags]
    public enum RuntimicKind
    {
        Unknown = 0,
        Bound = 1,
        Emitted = 2,
        Converted = 4,
        Semantic = 8,
		Structural = 16,
		Physical = 32,
        Cl = 64
    }
}
