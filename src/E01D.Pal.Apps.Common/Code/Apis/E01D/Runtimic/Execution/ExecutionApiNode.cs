using Root.Code.Apis.E01D.Runtimic.Execution.Bound;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution
{
    public class ExecutionApiNode<TContainer> : RuntimeApiNode<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public CecilApiMask_I Cecil => Container.Api.Runtimic.Infrastructure.Structural.Cecil;

	    public TypeApiMask_I Types => Container.Api.Runtimic.Execution.Metadata.Members.Types;

	    public ConversionApiMask_I Conversion => Container.Api.Runtimic.Execution.Conversion;

	    public BindingApiMask_I Bound => Container.Api.Runtimic.Execution.Bound;
	}

    public class ExecutionApiNode<TContainer, TUnderlying> : Api<TContainer, TUnderlying>
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
