using Root.Code.Apis.E01D.Runtimic.Execution;
using Root.Code.Apis.E01D.Runtimic.Infrastructure;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic
{
    

    public class RuntimicApi<TContainer> : RuntimeApiNode<TContainer>, RuntimicApi_I<TContainer>, RuntimicApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        [ValueSetDynamically]
        public new ExecutionApi_I<TContainer> Execution { get; set; }

        ExecutionApiMask_I RuntimicApiMask_I.Execution => Execution;

        [ValueSetDynamically]
        public new InfrastructureApi_I<TContainer> Infrastructure { get; set; }

        InfrastructureApiMask_I RuntimicApiMask_I.Infrastructure => Infrastructure;

        
    }
}

    