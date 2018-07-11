using Root.Code.Apis.E01D.Runtimic.Execution;
using Root.Code.Apis.E01D.Runtimic.Infrastructure;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic
{
    public interface RuntimicApi_I<TContainer>: Api_I<TContainer>, RuntimicApiMask_I
        where TContainer: RuntimicContainer_I<TContainer>
    {
        

        new ExecutionApi_I<TContainer> Execution { get; set; }

        new InfrastructureApi_I<TContainer> Infrastructure { get; set; }


    }
}
