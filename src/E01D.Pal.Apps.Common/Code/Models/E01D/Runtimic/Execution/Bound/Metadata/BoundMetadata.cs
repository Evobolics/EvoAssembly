using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata
{
    public abstract class BoundMetadata: BoundNode, Metadata_I
    {
        

        public string Name { get; set; }


    }
}
