namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Cl.Conceptual.Metadata.Members.Typal
{
    public interface ClReferenceOrValueType_I: ClNamedType_I
    {
        /// <summary>
        /// Returns the type's arity, the number of type parameters it takes.  Note, a non-generic type has zero arity.
        /// </summary>
        int Arity { get; }

        /// <summary>
        /// Gets whether this type or a containing type, has type parameters.
        /// </summary>
        bool IsGenericType { get; }
    }
}
