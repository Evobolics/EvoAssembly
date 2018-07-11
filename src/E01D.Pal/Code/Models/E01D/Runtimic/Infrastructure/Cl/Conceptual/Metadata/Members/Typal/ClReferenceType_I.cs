namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Cl.Conceptual.Metadata.Members.Typal
{
    /// <summary>
    /// Represents a class in conceptual form.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public interface ClReferenceType_I:ClNamedType_I
    {
        bool IsClass { get; }

        bool IsInterface { get; }
    }
}
