namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata
{
    public interface Metadata_I: InfrastructureNode_I, MetadataMask_I
    {
        /// <summary>
        /// Gets or sets the name of the metadata element.
        /// </summary>
        new string Name { get; set; }

        
    }
}
