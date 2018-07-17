using Root.Code.Apis.E01D.Runtimic.Execution;
using Root.Code.Apis.E01D.Runtimic.Infrastructure;
using Root.Code.Apis.E01D.Runtimic.Unified;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic
{
    

    public class RuntimicApi<TContainer> : RuntimeApiNode<TContainer>, RuntimicApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        
        public new ExecutionApi_I<TContainer> Execution { get; set; }

        ExecutionApiMask_I RuntimicApiMask_I.Execution => Execution;

        
        public new InfrastructureApi_I<TContainer> Infrastructure { get; set; }

        InfrastructureApiMask_I RuntimicApiMask_I.Infrastructure => Infrastructure;

		public new UnifiedApi_I<TContainer> Unified { get; set; }

	    UnifiedApiMask_I RuntimicApiMask_I.Unified => Unified;
	}
}

    