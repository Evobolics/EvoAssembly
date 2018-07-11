namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public interface SemanticMetadataStoreMask_I
    {
        // <summary>
        /// Gets or sets whether the model has been build out (filled in) with all the other metadata pieces it needs to be a complete piece of converted metadata.  Another way
        /// of thinking of it is does this object have it contents filled in or not .
        /// </summary>
        bool IsBuiltOut { get;  }
    }
}
