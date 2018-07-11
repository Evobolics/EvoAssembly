using Root.Code.Enums.E01D.Runtimic;

namespace Root.Code.Models.E01D.Runtimic
{
    public interface RuntimicNode_I
    {
        RuntimicKind RuntimicKind { get; }

        object ObjectNetwork { get; set; }
    }
}
