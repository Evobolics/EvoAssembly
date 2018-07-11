using System;

namespace Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata
{
    [Flags]
    public enum AssemblyKind
    {
        Unknown = 0,
        Bound = 1,
        Emitted = 2,
        Converted = 4
    }
}
