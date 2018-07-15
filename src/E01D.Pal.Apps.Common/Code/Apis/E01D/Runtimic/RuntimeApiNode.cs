using Root.Code.Apis.E01D.Runtimic.Execution;
using Root.Code.Apis.E01D.Runtimic.Infrastructure;
using Root.Code.Apis.E01D.Runtimic.Unified;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic
{
    public class RuntimeApiNode<TContainer>:Api<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public ExecutionApiMask_I Execution => Container.Api.Runtimic.Execution;

	    

		public InfrastructureApiMask_I Infrastructure => Container.Api.Runtimic.Infrastructure;

	    public UnifiedApiMask_I Unified => Container.Api.Runtimic.Unified;
	}
}
