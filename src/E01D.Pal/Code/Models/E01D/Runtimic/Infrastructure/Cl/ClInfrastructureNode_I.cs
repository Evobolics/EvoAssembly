using Root.Code.Enums.E01D.Runtimic.Infrastructure;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Cl
{
    public interface ClInfrastructureNode_I: InfrastructureNode_I
    {
        ClInfrasturcutureKind InfrasturcutureKind { get; }
    }
}
