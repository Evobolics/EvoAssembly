using Root.Code.Apis.E01D.Runtimic.Execution;
using Root.Code.Apis.E01D.Runtimic.Infrastructure;
using Root.Code.Apis.E01D.Runtimic.Models;
using Root.Code.Apis.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic
{
    public interface RuntimicApiMask_I
    {
        

        ExecutionApiMask_I Execution { get; }

	    IdentificationApiMask_I Identification { get; }

		InfrastructureApiMask_I Infrastructure { get; }

	    ModelApiMask_I Models { get; }

		UnifiedApiMask_I Unified { get; }
	}
}
