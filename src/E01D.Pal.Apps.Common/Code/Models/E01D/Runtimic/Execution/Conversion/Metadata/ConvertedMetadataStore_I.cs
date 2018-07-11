namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public interface ConvertedMetadataStore_I: ConvertedMetadataStoreMask_I
    {
        /// <summary>
        /// Gets or sets whether the model has been build out (filled in) with all the other metadata pieces it needs to be a complete piece of converted metadata.  Another way
        /// of thinking of it is does this object have it contents filled in or not .
        /// </summary>
        new bool IsBuiltOut { get; set; }
    }
}
