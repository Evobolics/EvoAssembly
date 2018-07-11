using System;

namespace Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal
{
    [Flags]
    public enum GenericTypeKind
    {
        Unknown = 0,
        Closed = 1,
        Open =2 ,
        HasTypeArguments = 4,
        HasTypeParameters = 8,
    }
}
