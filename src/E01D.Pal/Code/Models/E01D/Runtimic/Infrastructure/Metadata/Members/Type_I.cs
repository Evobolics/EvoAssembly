using Root.Code.Attributes.E01D;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members
{
    /// <summary>
    /// Represents a type in some type system.
    /// </summary>
    [PhenotypeClassifier]
    public interface Type_I: Member_I, TypeMask_I
    {
        

        new string AssemblyQualifiedName { get; set; }

        

        /// <summary>
        /// Gets or sets the full name of a type.
        /// </summary>
        new string FullName { get; set; }

        


    }
}
