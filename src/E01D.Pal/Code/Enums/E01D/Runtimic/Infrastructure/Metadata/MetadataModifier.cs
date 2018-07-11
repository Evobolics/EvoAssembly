using System;

namespace Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata
{
    [Flags]
    public enum MetadataModifier
    {
        /// <summary>
        /// Used to indicate no member modifier value has been assigned.
        /// </summary>
        Unknown = 0x0000,

        // ------ Class Modifiers ------ 

        Sealed = 0x0001,

        // ------ Member Modifiers ------ 

        /// <summary>
        /// Used to mark a method, property, indexer or event as virtual and indicates it may be be overriden in a derived class.
        /// </summary>
        Virtual = 0x0002,
        /// <summary>
        /// Used to mark a method, property, indexer or event as overridden and indicates it has be overriden in a derived class.
        /// </summary>
        Override = 0x0004,
        /// <summary>
        /// Used to mark a member as new and indicates it hides the previous implementation.
        /// </summary>
        New = 0x0008,

        /// <summary>
        /// Used to mark a field or variable as constant in value.
        /// </summary>
        Const = 0x0010,

        /// <summary>
        /// Used to mark a field or variable as constant in value.
        /// </summary>
        ReadOnly = 0x0020,

        /// <summary>
        /// Used to mark a field or variable as constant in value.
        /// </summary>
        Volatile = 0x0040,

        // ------ Metadata Modifiers -----

        /// <summary>
        /// Used to mark a class, struct, interface or delegate, or member as unsafe.
        /// </summary>
        Unsafe = 0x0080,
        /// <summary>
        /// Used to mark a classes, methods, properties, indexers and events as abstract.
        /// </summary>
        Abstract = 0x00F0,
        /// <summary>
        /// Used to mark classes, fields, methods, properties, operators, events and constructors as static.
        /// </summary>
        Static = 0x0100,

        // ------ Method Modifiers ------

        /// <summary>
        /// Used to mark a method that is implemented externally
        /// </summary>
        Extern = 0x0200,


        // ------ Method or Expression Modifiers ------

        /// <summary>
        /// Used ot specify that a method, anonymous method or lambda expression is asynchronous.
        /// </summary>
        Async = 0x0400,


        // ------ Visbility Modifiers -----

        Public = 0x0800,
        Internal = 0x0F00,
        Protected = 0x1000,
        Private = 0x2000,
        In = 0x4000,
        Out = 0x8000
    }
}
