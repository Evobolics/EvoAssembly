using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members
{
    public interface TypeMask_I:MemberMask_I
    {
        string AssemblyQualifiedName { get;  }

        /// <summary>
        /// Gets or sets the full name of a type.
        /// </summary>
        string FullName { get;  }

        /// <summary>
        /// Gets the kind of type this instance represents.  It can be a class, interface, delegate, struct, enum, pointer, array, or type parameter.
        /// </summary>
        /// <designNotes>The use of this enum enables the IsClass, IsInterface, etc, to become methods instead of properties, and thus simplifies the </designNotes>
        TypeKind TypeKind { get; }
    }
}
