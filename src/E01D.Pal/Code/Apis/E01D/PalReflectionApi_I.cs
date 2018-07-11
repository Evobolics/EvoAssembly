using Root.Code.Apis.E01D.Runtimic.Execution.Metadata;
using Root.Code.Attributes.E01D;

namespace Root.Code.Apis.E01D
{
    /// <summary>
    /// Represents a subset of the runtimic execution api that deals with providing type information for objects.
    /// </summary>
    [PhenotypeMask]
    public interface PalReflectionApi_I
    {
        PalMemberApi_I Members { get; }
        PalArrayApi_I Arrays { get;  }
    }
}
