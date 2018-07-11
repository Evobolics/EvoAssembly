using Root.Code.Enums.E01D.Runtimic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Cl
{
    public abstract class ClInfrastructureNode: ClInfrastructureNode_I
    {
        public abstract ClInfrasturcutureKind InfrasturcutureKind { get; }
        public RuntimicKind RuntimicKind { get; } = RuntimicKind.Cl;
        public object ObjectNetwork { get; set; }
    }
}
