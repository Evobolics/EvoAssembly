using Root.Code.Apis.E01D.Runtimic.Execution;
using Root.Code.Apis.E01D.Runtimic.Infrastructure;

namespace Root.Code.Apis.E01D.Runtimic
{
    public interface RuntimicApiMask_I
    {
        

        ExecutionApiMask_I Execution { get; }

        InfrastructureApiMask_I Infrastructure { get; }
    }
}
