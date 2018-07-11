using System;

namespace Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal
{
    [Flags]
    public enum TypeKind:long
    {
       
        Unknown = 0,
        Array =   0x1,
	    ByRef =   0x2,
		Class =   0x4,
        Closed =  0x8,

        CommonLanguage = 0x10,
        Global =         0x20,
        Delegate =       0x40,
        Definition =     0x80,

        Dynamic =        0x100,
        Enum =           0x200,
        Generic =        0x400,
        Interface =      0x800,

        Named =             0x1000,
        NullableValueType = 0x2000,
        Open =              0x4000,
        Pointer =           0x8000,

        Reference =     0x10000,
        ReferenceType = 0x20000,
        Simple =        0x40000,
        Solidity =      0x80000,

        Submission =                0x100000,
        SupportsBaseType =          0x200000,
        SupportsInterfaceTypeList = 0x400000,
        Struct =                    0x800000,

        TypeParameter = 0x1000000,
        ValueType =     0x2000000,
        Vector =        0x4000000,
        App =           0x8000000,

        Os =            0x10000000,
        Nested =        0x20000000,


	    RequiredModifier = 0x40000000
	}
}
