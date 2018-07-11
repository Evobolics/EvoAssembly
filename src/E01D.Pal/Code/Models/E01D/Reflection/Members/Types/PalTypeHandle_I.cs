using System;
using Root.Code.Models.E01D.Values;

namespace Root.Code.Models.E01D.Reflection.Members.Types
{
    /// <summary>
    /// If this is used by an AOT, the compiler has to handle its usage.
    /// </summary>
    public interface PalTypeHandle_I:Valued_I<IntPtr>
    {
    }
}
